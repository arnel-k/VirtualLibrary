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
    public class CategoryRepository : Repository<Category>, ICategoryRepository<Category>
    {
        private readonly LibraryContext _ctx;
        public CategoryRepository(LibraryContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public override async Task<Category> GetById(Guid guid)
        {
            return await _ctx.Categories.FirstOrDefaultAsync(x => x.Guid == guid);
        }
    }
}
