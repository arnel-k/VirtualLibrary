using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vLibrary.API.Services
{
    public interface ICRUDService<TModel, TSearch, TInsert, TUpdate> : IService<TModel, TSearch>
    {
        Task<TModel> Insert(TInsert insert);
        Task<TModel> Update(Guid guid, TUpdate update);
        Task<TModel> Delete(Guid guid);
    }
}
