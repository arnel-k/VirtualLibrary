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
    public class BookRepository : Repository<Book>, IBookRepository<Book>
    {
        private readonly LibraryContext _ctx;
        public BookRepository(LibraryContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public override async Task<Book> GetById(Guid guid)
        {
            return await _ctx.Books.FirstOrDefaultAsync(x => x.Guid == guid);
        }
    }
}
