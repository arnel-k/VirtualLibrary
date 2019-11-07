using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vLibrary.Api.Database;
using vLibrary.API.Context;
using vLibrary.API.Repositories.Interfaces;

namespace vLibrary.API.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository<Account>
    {
        private readonly LibraryContext _ctx;
        public AccountRepository(LibraryContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public override async Task<Account> GetById(Guid guid)
        {
            var entity = await _ctx.Accounts.FirstOrDefaultAsync(x => x.Guid == guid);
            return entity;
        }
    }
}
