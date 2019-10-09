using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Api.Database;

namespace vLibrary.API.Repositories.Interfaces
{
    public interface IEmployeeRepository<T> : IRepository<T> where T : class
    {
        new Task<Employee> GetById(Guid guid);
    }
}
