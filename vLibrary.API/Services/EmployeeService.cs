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
    public class EmployeeService : BaseCrudService<EmployeeDto, EmployeeSearchRequest, Employee, EmployeeUpsertRequest, EmployeeUpsertRequest>
    {
        private readonly IAddressRepository<Address> _addressRepository;
        private readonly ILibraryRepository<Library> _libraryRepository;
        private readonly IAccountRepository<Account> _accountRepository;
        public EmployeeService(IEmployeeRepository<Employee> repo, IAccountRepository<Account> accountRepository, IAddressRepository<Address> addressRepository, ILibraryRepository<Library> libraryRepository,IMapper mapper) : base(repo, mapper)
        {
            _addressRepository = addressRepository;
            _libraryRepository = libraryRepository;
            _accountRepository = accountRepository;
        }

        public override async Task<IEnumerable<EmployeeDto>> Get(EmployeeSearchRequest request)
        {
            var query = _repo.GetAsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.EmployeeName))
            {
                query = query.Where(x => x.FirstName.StartsWith(request.EmployeeName));

            }
            var employees = await query.Include(ac=>ac.Account).Include(a => a.Address).Include(l => l.Library).ToListAsync();
            return _mapper.Map<List<EmployeeDto>>(employees);
        }

        public override async Task<EmployeeDto> GetById(Guid guid)
        {
            var employee = await _repo.GetAsQueryable().Where(e => e.Guid == guid).Include(ac=>ac.Account).Include(a => a.Address).Include(l => l.Library).FirstOrDefaultAsync();
            return _mapper.Map<EmployeeDto>(employee);

        }

        public override async Task<EmployeeDto> Insert(EmployeeUpsertRequest insert)
        {
            var guid = Guid.NewGuid();
            var library = await _libraryRepository.GetById(insert.LibraryDtoGuid);
            var address = await _addressRepository.GetById(insert.AddressDtoGuid);
            var account = await _accountRepository.GetById(insert.AccountDtoGuid);
          

            ///TODO: add accountid 
            var toInsert = new EmployeeInsertRequest
            {
                Guid = guid,
                BirthDate = insert.BirthDate,
                AccountId = account.Id,
                AddressId = address.Id,
                LibraryId = library.Id,
                FirstName = insert.FirstName,
                LastName = insert.LastName,
                Gender = insert.Gender,
                Email = insert.Email,
                Picture = insert.Picture,
                Phone = insert.Phone,
                

            };

            var entity = _mapper.Map<Employee>(toInsert);
            _repo.Insert(entity);
            await _repo.Save();
            return _mapper.Map<EmployeeDto>(entity);
            
        }

        public override async Task<EmployeeDto> Update(Guid guid, EmployeeUpsertRequest update)
        {
            var entity = await _repo.GetById(guid);

            if(update.GetType().GetProperty("Guid") != null)
            {
                update.GetType().GetProperty("Guid").SetValue(update, guid);

            }

            var library = await _libraryRepository.GetById(update.LibraryDtoGuid);
            var address = await _addressRepository.GetById(update.AddressDtoGuid);
            var account = await _addressRepository.GetById(update.AccountDtoGuid);
            var toInsert = new EmployeeInsertRequest
            {
                Guid = guid,
                BirthDate = update.BirthDate.Value,
                AddressId = address.Id,
                LibraryId = library.Id,
                AccountId = account.Id,   ///TODO: check 
                FirstName = update.FirstName,
                LastName = update.LastName,
                Gender = update.Gender,
                Email = update.Email,
                Picture = update.Picture,
                Phone = update.Phone
            };
            _repo.Update(_mapper.Map(toInsert, entity));
            await _repo.Save();
            return _mapper.Map<EmployeeDto>(entity);

        }

    }
}
