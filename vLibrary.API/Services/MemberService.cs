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
    public class MemberService : BaseCrudService<MemberDto, MemberSearchRequest, Member, MemberUpsertRequests, MemberUpsertRequests>, ICRUDService<MemberDto, MemberSearchRequest, MemberUpsertRequests, MemberUpsertRequests>
    {
        private readonly IAccountRepository<Account> _accountRepository;
        public MemberService(IMemberRepository<Member> repo, IAccountRepository<Account> accountRepository, IMapper mapper) : base(repo, mapper)
        {
            _accountRepository = accountRepository;
        }
        public override  async Task<MemberDto> Insert(MemberUpsertRequests insert)
        {
            var query = _accountRepository.GetAsQueryable();
            if (string.IsNullOrWhiteSpace(insert.Password)) throw new UserException("Password is required!");
            if (query.Any(x => x.UserName == insert.UserName)) throw new UserException($"Username {insert.UserName} is already taken!");
            byte[] passwordHash, passwordSalt;
            PasswordHashing.CreatePasswordHash(insert.Password, out passwordHash, out passwordSalt);

            var entity = _mapper.Map<Member>(insert);
            entity.NumberOfBooksLoaned = 0;
            entity.DateOfMemberShip = DateTime.Now;
            var account = new Account
            {
                Guid = Guid.NewGuid(),
                UserName = insert.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = vLibrary.Api.Database.Enums.Role.Member,
                AccountStatus = Api.Database.Enums.AccountStatus.Active,
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
            return _mapper.Map<MemberDto>(entity);
        }

        public override async Task<MemberDto> Update(Guid guid, MemberUpsertRequests update)
        {
            var entity = await _repo.GetById(guid);
            var query = _accountRepository.GetAsQueryable();
            if (string.IsNullOrWhiteSpace(update.Password)) throw new UserException("Password is required!");
            byte[] passwordHash, passwordSalt;

            PasswordHashing.CreatePasswordHash(update.Password, out passwordHash, out passwordSalt);
            entity.Address.City = update.City;
            entity.Address.Street = update.Street;
            entity.Address.ZipCode = update.ZipCode;
            entity.Account.AccountStatus = (vLibrary.Api.Database.Enums.AccountStatus)update.AccountStatus;
            entity.Account.PasswordHash = passwordHash;
            entity.Account.PasswordSalt = passwordSalt;

            _repo.Update(_mapper.Map(update, entity));
            await _repo.Save();
            return _mapper.Map<MemberDto>(entity);
        }
        public override async Task<MemberDto> GetById(Guid guid)
        {
            var member = await _repo.GetAsQueryable().Where(e => e.Guid == guid).Include(ac => ac.Account).Include(a => a.Address).Include(l => l.Library).FirstOrDefaultAsync();
            return _mapper.Map<MemberDto>(member);
        }
        public override async Task<IEnumerable<MemberDto>> Get(MemberSearchRequest request)
        {
            var query = _repo.GetAsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.FName))
            {
                query = query.Where(x => x.FirstName.StartsWith(request.FName));

            }
            var employees = await query.Include(ac => ac.Account).Include(a => a.Address).Include(l => l.Library).ToListAsync();
            return _mapper.Map<List<MemberDto>>(employees);
        }


    }
}
