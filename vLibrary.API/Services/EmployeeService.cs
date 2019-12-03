using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vLibrary.Api.Database;
using vLibrary.API.Exceptions;
using vLibrary.API.Helpers;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API.Services
{
    public class EmployeeService : BaseCrudService<EmployeeDto, EmployeeSearchRequest, Employee, EmployeeUpsertRequest, EmployeeUpsertRequest>
    {
      
        private readonly IAccountRepository<Account> _accountRepository;
        public EmployeeService(IEmployeeRepository<Employee> repo, IAccountRepository<Account> accountRepository,  IMapper mapper) : base(repo, mapper)
        {
            
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
            var query = _accountRepository.GetAsQueryable();
            if (string.IsNullOrWhiteSpace(insert.Password)) throw new UserException("Password is required!");
            if (query.Any(x => x.UserName == insert.UserName)) throw new UserException($"Username {insert.UserName} is already taken !");
            byte[] passwordHash, passwordSalt;

            PasswordHashing.CreatePasswordHash(insert.Password, out passwordHash, out passwordSalt);
            
            var entity = _mapper.Map<Employee>(insert);
            var account = new Account
            {
                Guid = Guid.NewGuid(),
                UserName = insert.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = (vLibrary.Api.Database.Enums.Role)insert.Role,
                AccountStatus = (vLibrary.Api.Database.Enums.AccountStatus)insert.AccountStatus
            };
            var address = new Address
            {
                Guid = Guid.NewGuid(),
                Street = insert.Street,
                City = insert.City,
                ZipCode = insert.ZipCode
            };
            entity.Account = account;
            entity.Address = address;
            entity.LibraryId = 1;
            _repo.Insert(entity);
            await _repo.Save();
            return _mapper.Map<EmployeeDto>(entity);
            
        }

        public override async Task<EmployeeDto> Update(Guid guid, EmployeeUpsertRequest update)
        {
            var entity = await _repo.GetById(guid);
            var query = _accountRepository.GetAsQueryable();
            if (string.IsNullOrWhiteSpace(update.Password)) throw new UserException("Password is required!");
            //if (query.Any(x => x.UserName == update.UserName)) throw new UserException($"Username {update.UserName} is already taken !");
            byte[] passwordHash, passwordSalt;

            PasswordHashing.CreatePasswordHash(update.Password, out passwordHash, out passwordSalt);

            if (update.GetType().GetProperty("Guid") != null)
             {
                 update.GetType().GetProperty("Guid").SetValue(update, guid);

             }
            
            entity.Address.City = update.City;
            entity.Address.Street = update.Street;
            entity.Address.ZipCode = update.ZipCode;
            entity.Account.AccountStatus = (vLibrary.Api.Database.Enums.AccountStatus)update.AccountStatus;
            entity.Account.PasswordHash = passwordHash;
            entity.Account.PasswordSalt = passwordSalt;

            _repo.Update(_mapper.Map(update, entity));
            await _repo.Save();
            return _mapper.Map<EmployeeDto>(entity);
             
         }


        


    }
}
