using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vLibrary.Api.Database;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API.Services
{
    public class BookService : BaseCrudService<BookDto, BookSearchRequest, Book, BookUpsertRequest, BookUpsertRequest>, ICRUDService<BookDto, BookSearchRequest, BookUpsertRequest, BookUpsertRequest>
    {
        private readonly ILibraryRepository<Library> _libraryRepository;
        private readonly IPublisherRepository<Publisher> _publisherRepository;
        private readonly ICategoryRepository<Category> _categoryRepository;
        private readonly IRackRepository<Rack> _rackRepository;
        
        public BookService(IBookRepository<Book> repo, ILibraryRepository<Library> libraryRepository,
            IPublisherRepository<Publisher> publisherRepository,
            ICategoryRepository<Category> categoryRepository,
            IRackRepository<Rack> rackRepository,
            IMapper mapper) 
            : base(repo, mapper)
        {
            _libraryRepository = libraryRepository;
            _publisherRepository = publisherRepository;
            _categoryRepository = categoryRepository;
            _rackRepository = rackRepository;
        }
        public override async Task<IEnumerable<BookDto>> Get(BookSearchRequest request)
        {

            var query = _repo.GetAsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Title))
            {
                query = query.Where(x => x.Title.StartsWith(request.Title));

            }

            var books = await query.Include(p => p.Publisher).Include(c => c.Category).Include(r => r.Rack).Include(lib => lib.Library).ToListAsync();
            return _mapper.Map<List<BookDto>>(books);
        }

        public override async Task<BookDto> Insert(BookUpsertRequest insert)
        {
            var guid = Guid.NewGuid();
            //insert.GetType().GetProperty("Guid").SetValue(insert, guid);
            
            var library = await _libraryRepository.GetById(insert.LibraryDtoGuid);
            var category = await _categoryRepository.GetById(insert.CategoryDtoGuid);
            var publisher = await _publisherRepository.GetById(insert.PublisherDtoGuid);
            var rack = await _rackRepository.GetById(insert.RackDtoGuid);
            var toInsert = new BookInsertRequest
            {
                Guid = guid,
                ISBN = insert.ISBN,
                RackId  =  rack.Id,
                BookStatus = insert.BookStatus,
                CategoryId = category.Id,
                Image = insert.Image,
                LibraryId = library.Id,
                NumberOfPages = insert.NumberOfPages,
                PublicationDate = insert.PublicationDate,
                PublisherId = publisher.Id,
                Subject = insert.Subject,
                Title = insert.Title
            };
            var entity = _mapper.Map<Book>(toInsert);
            _repo.Insert(entity);
            await _repo.Save();
            return _mapper.Map<BookDto>(entity);
        }

        public override async Task<BookDto> Update(Guid guid, BookUpsertRequest update)
        {
            var entity = await _repo.GetById(guid);
            if (update.GetType().GetProperty("Guid") != null)
            {
                update.GetType().GetProperty("Guid").SetValue(update, guid);
            }
            var library = await _libraryRepository.GetById(update.LibraryDtoGuid);
            var category = await _categoryRepository.GetById(update.CategoryDtoGuid);
            var publisher = await _publisherRepository.GetById(update.PublisherDtoGuid);
            var rack = await _rackRepository.GetById(update.RackDtoGuid);
            var toInsert = new BookInsertRequest
            {
                Guid = guid,
                ISBN = update.ISBN,
                RackId = rack.Id,
                BookStatus = update.BookStatus,
                CategoryId = category.Id,
                Image = update.Image,
                LibraryId = library.Id,
                NumberOfPages = update.NumberOfPages,
                PublicationDate = update.PublicationDate,
                PublisherId = publisher.Id,
                Subject = update.Subject,
                Title = update.Title
            };
            _repo.Update(_mapper.Map(toInsert, entity));
            await _repo.Save();
            return _mapper.Map<BookDto>(entity);
        }
    }
}
