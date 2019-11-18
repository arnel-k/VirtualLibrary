using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vLibrary.API.Services;
using vLibrary.Model.Enums;

namespace vLibrary.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T, TSearch> : ControllerBase
    {
        private readonly IService<T, TSearch> _service;
        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        }


        [HttpGet]
        public virtual async Task<IEnumerable<T>> Get([FromQuery]TSearch search)
        {
            return await _service.Get(search);
        }

        [HttpGet("{id}")]
        public virtual async Task<T> GetById(Guid id)
        {
            return await _service.GetById(id);
        }



    }
}