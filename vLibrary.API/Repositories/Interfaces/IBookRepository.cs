using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Api.Database;

namespace vLibrary.API.Repositories.Interfaces
{
    public interface IBookRepository<T> : IRepository<T> where T :class
    {
        new Task<T> GetById(Guid guid);
    }

   
}
