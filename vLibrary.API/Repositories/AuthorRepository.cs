using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.API.Models;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.Model;

namespace vLibrary.API.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository<Author>
    {
        public AuthorRepository(LibraryContext ctx ):base(ctx)
        {

        }
    }
}
