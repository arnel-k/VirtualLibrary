using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Api.Database;

namespace vLibrary.API.Repositories.Interfaces
{
    public interface IAddressRepository<T> : IRepository<T> where T :class
    {
        new Task<Address> GetById(Guid guid);
    }
}
