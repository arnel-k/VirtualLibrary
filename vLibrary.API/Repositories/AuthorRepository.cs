using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Api.Database;
using vLibrary.API.Context;
using vLibrary.API.Repositories.Interfaces;


namespace vLibrary.API.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository<Author>
    {
        private readonly LibraryContext _ctx;
        public AuthorRepository(LibraryContext ctx ):base(ctx)
        {
            _ctx = ctx;
        }

        public override async Task<Author> GetById(Guid guid)
        {
            var entity = await _ctx.Authors.FirstOrDefaultAsync(x => x.Guid == guid);
            return entity;
        }
    }
}
