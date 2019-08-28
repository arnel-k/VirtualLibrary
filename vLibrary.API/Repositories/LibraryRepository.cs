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
    public class LibraryRepository : Repository<Library>, ILibraryRepository<Library>
    {
        private readonly LibraryContext _ctx;
        public LibraryRepository(LibraryContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public override async Task<Library> GetById(Guid guid)
        {
            return await _ctx.Libraries.FirstOrDefaultAsync(x => x.Guid == guid);
        }
    }
}
