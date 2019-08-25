using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.API.Context;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.Model;

namespace vLibrary.API.Services
{
    public class BaseService<TModel, TSearch,TDatabase> : IService<TModel, TSearch> where TDatabase: class
    {
        protected readonly IRepository<TDatabase> _repo;
        //protected readonly LibraryContext _ctx;
        protected readonly IMapper _mapper;

        public BaseService(IRepository<TDatabase> repo,  IMapper mapper)
        {
            _repo = repo;
            //_ctx = ctx;
            _mapper = mapper;
        }
      

        public virtual  async Task<IEnumerable<TModel>> Get(TSearch search)
        {
            var query = _repo.GetAsQueryable();
            //var query = _ctx.Set<TDatabase>().AsQueryable();
            var list = await query.ToListAsync();
            return _mapper.Map<List<TModel>>(list);
        }

        public virtual async Task<TModel> GetById(Guid guid)
        {
            var entity = await _repo.GetById(guid);
            return _mapper.Map<TModel>(entity);
        }
    }
}
