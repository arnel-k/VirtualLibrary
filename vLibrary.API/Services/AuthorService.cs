using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Api.Database;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository<Author> _repo;
        private readonly IMapper _mapper;
        public AuthorService(IAuthorRepository<Author> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Delete(Guid guid)
        {
            var entity = await _repo.GetById(guid);
          
            _repo.Delete(entity);
            await _repo.Save();
            return _mapper.Map<AuthorDto>(entity);
        }

        public async Task<IEnumerable<AuthorDto>> Get(AuthorsSearchRequest request)
        {
            var query = _repo.GetAsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.FName))
            {
                query = query.Where(x => x.FName.StartsWith(request.FName));

            }

            if (!string.IsNullOrWhiteSpace(request?.LName))
            {
                query = query.Where(x => x.LName.StartsWith(request.LName));
            }
            var authors = await query.ToListAsync();
            return _mapper.Map<List<AuthorDto>>(authors);
           
        }

        public async Task<AuthorDto> GetById(Guid guid)
        {
            var entity = await _repo.GetById(guid);
            return _mapper.Map<AuthorDto>(entity);
        }

        public async Task<AuthorDto> Insert(AuthorInsertRequest request)
        {
            request.Guid = Guid.NewGuid();
            var entity = _mapper.Map<Author>(request);
            _repo.Insert(entity);
            await _repo.Save();
            return _mapper.Map<AuthorDto>(entity);
        }

        public async Task<AuthorDto> Update(Guid guid, AuthorUpdateRequest request)
        {
            var entity = await _repo.GetById(guid);
            _repo.Update(_mapper.Map(request, entity));
            await _repo.Save();
            return _mapper.Map<AuthorDto>(entity);


        }

       
    }
}
