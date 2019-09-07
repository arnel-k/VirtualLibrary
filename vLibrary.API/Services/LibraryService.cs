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
    public class LibraryService : BaseCrudService<LibraryDto, LibrarySearchRequest, Library, LibraryUpsertRequest, LibraryUpsertRequest>, ICRUDService<LibraryDto, LibrarySearchRequest, LibraryUpsertRequest, LibraryUpsertRequest>
    {
         
        public LibraryService(ILibraryRepository<Library> repo, IMapper mapper) : base(repo, mapper)
        {
        }

        public override async Task<IEnumerable<LibraryDto>> Get(LibrarySearchRequest request)
        {

            var query = _repo.GetAsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Name))
            {
                query = query.Where(x => x.Name.StartsWith(request.Name));

            }

            var libraries = await query.ToListAsync();
            return _mapper.Map<List<LibraryDto>>(libraries);
        }
    }
}
