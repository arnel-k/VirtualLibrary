using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vLibrary.API.Services;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        
        public AuthorsController(IAuthorService authorService)
        {

            _authorService = authorService;
            
        }
        [HttpGet]
        public async Task<IEnumerable<AuthorDto>> Get([FromQuery] AuthorsSearchRequest request)
        {
            //Thread.Sleep(5000);
            return await _authorService.Get(request);
        }
        [HttpGet("{guid}")]
        public async Task<IActionResult> GetById(Guid guid)
        {
            var entity = await _authorService.GetById(guid);
            if(entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(AuthorInsertRequest requst)
        {
            var entity = await _authorService.Insert(requst);
            return CreatedAtAction(nameof(GetById), new { guid = requst.Guid }, requst);
        }
        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateAuthor(Guid guid, AuthorUpdateRequest request)
        {
            var entity = _authorService.GetById(guid);
            if(entity == null)
            {
                return NotFound();
            }
            await _authorService.Update(guid, request);
            return NoContent();
        }
        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteAuthor(Guid guid)
        {
            var toDelete = _authorService.GetById(guid);
            if(toDelete == null)
            {
                return NotFound();
            }
            await _authorService.Delete(guid);
            return NoContent();
        }
    }
}