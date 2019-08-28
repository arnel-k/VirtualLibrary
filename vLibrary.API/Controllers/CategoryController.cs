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

    public class CategoryController : BaseCRUDController<CategoryDto, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest>
    {
        public CategoryController(ICRUDService<CategoryDto, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest> service) : base(service)
        {
        }
    }
}