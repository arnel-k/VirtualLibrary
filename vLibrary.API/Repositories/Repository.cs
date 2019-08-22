using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.API.Models;
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
        public async Task Delete(int id)
        {
            T entity = await _set.FindAsync(id);
             _set.Remove(entity);
            
        }

        public  async Task<IEnumerable<T>> GetAll()
        {
            return await _set.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _set.FindAsync(id);
        }

        public void Insert(T obj)
        {
            _set.Add(obj);
            
        }

        public void Update(T obj)
        {
            _set.Attach(obj);
            _ctx.Entry(obj).State = EntityState.Modified;
        }
        public async Task Save()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
