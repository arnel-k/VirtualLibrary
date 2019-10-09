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
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseCRUDController<EmployeeDto, EmployeeSearchRequest, EmployeeUpsertRequest, EmployeeUpsertRequest>
    {
        public EmployeeController(ICRUDService<EmployeeDto, EmployeeSearchRequest, EmployeeUpsertRequest, EmployeeUpsertRequest> service) : base(service)
        {
        }
    }
}