using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using vLibrary.API.Repositories.Interfaces;

namespace vLibrary.API.Services
{
    public class BaseCrudService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, TSearch, TDatabase>, ICRUDService<TModel, TSearch, TInsert, TUpdate> where TDatabase : class
    { 
        public BaseCrudService(IRepository<TDatabase> repo, IMapper mapper) : base(repo, mapper)
        {
        }

        public virtual async Task<TModel> Delete(Guid guid)
        {
            var entity = await _repo.GetById(guid);
            _repo.Delete(entity);
            await _repo.Save();
            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> Insert(TInsert insert)
        {
            
            var guid = Guid.NewGuid();
            insert.GetType().GetProperty("Guid").SetValue(insert, guid);
            var entity = _mapper.Map<TDatabase>(insert);
            _repo.Insert(entity);
            await _repo.Save();
            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> Update(Guid guid, TUpdate update)
        {
            var entity = await _repo.GetById(guid);
            if (update.GetType().GetProperty("Guid") != null)
            {
                update.GetType().GetProperty("Guid").SetValue(update, guid);
            }
            
            _repo.Update(_mapper.Map(update, entity));
            await _repo.Save();
            return _mapper.Map<TModel>(entity);
        }
    }
}
