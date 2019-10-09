using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vLibrary.Api.Database;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API.Services
{
    public class CategoryService : BaseCrudService<CategoryDto, CategorySearchRequest, Category, CategoryUpsertRequest, CategoryUpsertRequest>, ICRUDService<CategoryDto, CategorySearchRequest, CategoryUpsertRequest, CategoryUpsertRequest>
    {
        public CategoryService(ICategoryRepository<Category> repo, IMapper mapper) : base(repo, mapper)
        {
        }
        public override async Task<IEnumerable<CategoryDto>> Get(CategorySearchRequest request)
        {

            var query = _repo.GetAsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.CategoryName))
            {
                query = query.Where(x => x.CategoryName.StartsWith(request.CategoryName));
                
            }

            var categories = await query.ToListAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
