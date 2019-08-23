using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vLibrary.Api.Database;
using vLibrary.API.Services;


namespace vLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _service;
        public MemberController(IMemberService service)
        {
            _service = service;
        }
       
        [HttpGet]
        public async Task<IEnumerable<Member>> Get()
        {
            return await _service.Get();
        }
       
    }
}