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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository<Employee>
    {
        private readonly LibraryContext _ctx;
        public EmployeeRepository(LibraryContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public override async Task<Employee> GetById(Guid guid)
        {
            return await _ctx.Employees.FirstOrDefaultAsync(x => x.Guid == guid);
        }


    }
}
