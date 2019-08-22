using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vLibrary.API.Repositories.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        Task Delete(int id);
        Task Save();
    }
}
