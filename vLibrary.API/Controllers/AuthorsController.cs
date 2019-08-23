﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vLibrary.API.Context;
using vLibrary.API.Dtos;
using vLibrary.API.Requests;
using vLibrary.API.Services;


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
        public async Task<IEnumerable<AuthorDto>> Get()
        {
            return await _authorService.Get();
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