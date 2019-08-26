using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Api.Database;
using vLibrary.API.Context;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API.Services
{

    public class AuthorService : BaseCrudService<AuthorDto, AuthorsSearchRequest, Author, AuthorInsertRequest, AuthorUpdateRequest>, ICRUDService<AuthorDto, AuthorsSearchRequest, AuthorInsertRequest, AuthorUpdateRequest>
    {
        public AuthorService(IAuthorRepository<Author> repo, IMapper mapper) : base(repo, mapper)
        {
        }

        public override async Task<IEnumerable<AuthorDto>> Get(AuthorsSearchRequest request)
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
       
        
    }
}
