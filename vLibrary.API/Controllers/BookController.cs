using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vLibrary.API.Context;
using vLibrary.API.Services;
using vLibrary.Model;
using vLibrary.Model.Enums;
using vLibrary.Model.Requests;

namespace vLibrary.API.Controllers
{
    //[Helpers.AppRole(Role.Librarian)]
    public class BookController : BaseCRUDController<BookDto, BookSearchRequest, BookUpsertRequest, BookUpsertRequest>
    {
    
        public BookController(ICRUDService<BookDto, BookSearchRequest, BookUpsertRequest, BookUpsertRequest> service) : base(service)
        {
            
        }

    }
}