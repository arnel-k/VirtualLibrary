using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vLibrary.API.Services;
using vLibrary.Model;

namespace vLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly ILoggerService _loggerService;
        private readonly IAuthorService _authorService;
        public TestController(ILoggerService loggerService, IAuthorService authorService)
        {
            _loggerService = loggerService;
            _authorService = authorService;
        }
        [HttpGet]
        //    public string Get(string name)
        //    {
        //        return _loggerService.Log(name);
        //    }
        public async Task<IEnumerable<Author>> Get()
        {
            return await _authorService.Get();
        }
    }
}