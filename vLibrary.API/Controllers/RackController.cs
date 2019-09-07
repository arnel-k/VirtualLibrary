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

    public class RackController : BaseCRUDController<RackDto, RackSearchRequest, RackUpsertRequest, RackUpsertRequest>
    {
        public RackController(ICRUDService<RackDto, RackSearchRequest, RackUpsertRequest, RackUpsertRequest> service) : base(service)
        {
        }
    }
}