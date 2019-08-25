using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vLibrary.API.Services;

namespace vLibrary.API.Controllers
{
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    {
        protected readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service = null;
        public BaseCRUDController(ICRUDService<T, TSearch,TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }
        [HttpPut("{guid}")]
        public virtual async Task<ActionResult<T>> Update(Guid guid, TUpdate update)
        {
            var entity = _service.GetById(guid);
            if (entity == null)
            {
                return NotFound();
            }
            return await _service.Update(guid, update);
        }
        [HttpDelete("{guid}")]
        public virtual async Task<ActionResult<T>> Delete(Guid guid)
        {
            var toDelete = _service.GetById(guid);
            if (toDelete == null)
            {
                return NotFound();
            }
            return await _service.Delete(guid);
        }

        [HttpPost]
        public virtual async Task<T> Insert(TInsert insert)
        {
            var entity = await _service.Insert(insert);
            return entity;
        }
    }
}