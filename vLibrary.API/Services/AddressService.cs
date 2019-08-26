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
    public class AddressService : BaseCrudService<AddressDto, AddressSearchRequest, Address, AddressUpsertRequest, AddressUpsertRequest>, ICRUDService<AddressDto, AddressSearchRequest, AddressUpsertRequest, AddressUpsertRequest>
    {
        public AddressService(IAddressRepository<Address> repo, IMapper mapper) : base(repo, mapper)
        {
        }
        public override async Task<IEnumerable<AddressDto>> Get(AddressSearchRequest request)
        {

            var query = _repo.GetAsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.StreetName))
            {
                query = query.Where(x => x.Street.StartsWith(request.StreetName));

            }

            var address = await query.ToListAsync();
            return _mapper.Map<List<AddressDto>>(address);
        }
        
    }
}
