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
    public class AddressRepository : Repository<Address>, IAddressRepository<Address>
    {
        private readonly LibraryContext _ctx;
        public AddressRepository(LibraryContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public override async Task<Address> GetById(Guid guid)
        {
            var entity = await _ctx.Addresses.FirstOrDefaultAsync(x => x.Guid == guid);
            return entity;
        }
    }
}
