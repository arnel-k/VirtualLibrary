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

    public class LibraryController : BaseCRUDController<LibraryDto, LibrarySearchRequest, LibraryUpsertRequest, LibraryUpsertRequest>
    {
        public LibraryController(ICRUDService<LibraryDto, LibrarySearchRequest, LibraryUpsertRequest, LibraryUpsertRequest> service) : base(service)
        {
        }
    }
}