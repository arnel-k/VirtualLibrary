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

    public class AuthorsController : BaseCRUDController<AuthorDto, AuthorsSearchRequest,AuthorInsertRequest,AuthorUpdateRequest>
    {
        
        public AuthorsController(ICRUDService<AuthorDto, AuthorsSearchRequest, AuthorInsertRequest, AuthorUpdateRequest> service) : base(service)
        {
        }

        [HttpPut("{guid}")]
        public override async Task<ActionResult<AuthorDto>> Update(Guid guid, AuthorUpdateRequest update)
        {
            var entity = _service.GetById(guid);
            if (entity == null)
            {
                return NotFound();
            }
            return await _service.Update(guid, update);
        }
    }
}