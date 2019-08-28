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
    public class RackRepository : Repository<Rack>, IRackRepository<Rack>
    {
        private readonly LibraryContext _ctx;
        public RackRepository(LibraryContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public override async Task<Rack> GetById(Guid guid)
        {
            return await _ctx.Racks.FirstOrDefaultAsync(x => x.Guid == guid);
        }
    }
}
