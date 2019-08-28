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
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository<Publisher>
    {
        private readonly LibraryContext _ctx;
        public PublisherRepository(LibraryContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public override async Task<Publisher> GetById(Guid guid)
        {
            return await _ctx.Publishers.FirstOrDefaultAsync(x => x.Guid == guid);
        }
    }
}
