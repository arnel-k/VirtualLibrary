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
    public class RackService : BaseCrudService<RackDto, RackSearchRequest, Rack, RackUpsertRequest, RackUpsertRequest>, ICRUDService<RackDto, RackSearchRequest, RackUpsertRequest, RackUpsertRequest>
    {
        public RackService(IRackRepository<Rack> repo, IMapper mapper) : base(repo, mapper)
        {
        }

        public override async Task<IEnumerable<RackDto>> Get(RackSearchRequest request)
        {

            var query = _repo.GetAsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.RackNumber))
            {
                query = query.Where(x => x.RackNumber == int.Parse(request.RackNumber));

            }

            var list = await query.ToListAsync();
            return _mapper.Map<List<RackDto>>(list);
        }
    }
}
