using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vLibrary.API.Services;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API.Controllers
{
    public class AddressController : BaseCRUDController<AddressDto, AddressSearchRequest, AddressUpsertRequest, AddressUpsertRequest>
    {
        public AddressController(ICRUDService<AddressDto, AddressSearchRequest, AddressUpsertRequest, AddressUpsertRequest> service) : base(service)
        {
        }

        [HttpPut("{guid}")]
        public override async Task<ActionResult<AddressDto>> Update(Guid guid, AddressUpsertRequest update)
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