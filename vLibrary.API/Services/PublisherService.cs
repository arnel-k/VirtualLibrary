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
    public class PublisherService : BaseCrudService<PublisherDto, PublisherSearchRequest, Publisher, PublisherUpsertRequest, PublisherUpsertRequest>, ICRUDService<PublisherDto, PublisherSearchRequest, PublisherUpsertRequest, PublisherUpsertRequest>
    {
        public PublisherService(IPublisherRepository<Publisher> repo, IMapper mapper) : base(repo, mapper)
        {
        }

        public override async Task<IEnumerable<PublisherDto>> Get(PublisherSearchRequest request)
        {

            var query = _repo.GetAsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.PublisherName))
            {
                query = query.Where(x => x.PublisherName.StartsWith(request.PublisherName));

            }

            var list = await query.ToListAsync();
            return _mapper.Map<List<PublisherDto>>(list);
        }
    }
}
