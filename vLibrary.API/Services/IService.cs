using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vLibrary.API.Services
{
    public interface IService<T,TSearch>
    {
        Task<IEnumerable<T>> Get(TSearch search);
        Task<T> GetById(Guid guid);
    }
}
