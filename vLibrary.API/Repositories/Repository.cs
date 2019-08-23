using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.API.Context;
using vLibrary.API.Repositories.Interfaces;

namespace vLibrary.API.Repositories
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private readonly LibraryContext _ctx;
        private DbSet<T> _set;
        public Repository(LibraryContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }
        public virtual void Delete(T entity)
        {
             _set.Remove(entity);
            
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _set.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid guid)
        {
            return await _set.FindAsync(guid);
        }

        public virtual void Insert(T obj)
        {
            _set.Add(obj);
            
        }

        public virtual void Update(T obj)
        {
            _set.Attach(obj);
            _ctx.Entry(obj).State = EntityState.Modified;
        }
        public virtual async Task Save()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
