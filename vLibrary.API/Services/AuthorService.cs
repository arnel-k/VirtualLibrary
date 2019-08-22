using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.Model;

namespace vLibrary.API.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository<Author> _repo;
        public AuthorService(IAuthorRepository<Author> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Author>> Get()
        {
            return await _repo.GetAll();
        }
    }
}
