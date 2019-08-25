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
    public class AddressController : BaseCRUDController<AuthorDto, AuthorsSearchRequest, AuthorInsertRequest, AuthorUpdateRequest>
    {
        public AddressController(ICRUDService<AuthorDto, AuthorsSearchRequest, AuthorInsertRequest, AuthorUpdateRequest> service) : base(service)
        {
        }

        ///TO DO: Implement address, repo, service 
    }
}