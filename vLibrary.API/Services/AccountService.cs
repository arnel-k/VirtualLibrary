using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using vLibrary.Api.Database;
using vLibrary.API.Exceptions;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API.Services
{
    public class AccountService : BaseCrudService<AccountDto, AccountSearchRequest, Account, AccountUpsertRequest, AccountUpsertRequest>, ICRUDService<AccountDto, AccountSearchRequest, AccountUpsertRequest, AccountUpsertRequest>, IAccountService<AccountDto, AccountSearchRequest>
    {

        public AccountService(IAccountRepository<Account> repo, IMapper mapper) : base(repo, mapper)
        {
        }
        ///TODO: To implement
        
        public async  Task<AccountDto> Authenticate(string username, string password)
        {
            var query = _repo.GetAsQueryable();
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                query = query.Where(x => x.UserName == username);
            }
            var account = await query.FirstOrDefaultAsync();
            if(account == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
                return null;
            return _mapper.Map<AccountDto>(account);

        }

        //public override async Task<AccountDto> Insert(AccountUpsertRequest insert)
        //{
        //    var query = _repo.GetAsQueryable();
        //    if (string.IsNullOrWhiteSpace(insert.Password)) throw new UserException("Password is required!");
        //    if (query.Any(x => x.UserName == insert.UserName)) throw new UserException($"Username {insert.UserName} is already taken !");
        //    byte[] passwordHash, passwordSalt;

        //    CreatePasswordHash(insert.Password, out passwordHash, out passwordSalt);

        //    var toInsert = new AccountInsertRequest
        //    {
        //        Guid = Guid.NewGuid(),
        //        UserName = insert.UserName,
        //        PasswordHash = passwordHash,
        //        PasswordSalt = passwordSalt,
        //        Role = insert.Role,
        //        AccountStatus = insert.AccountStatus

        //    };

        //    var entity = _mapper.Map<Account>(toInsert);
        //    _repo.Insert(entity);
        //    await _repo.Save();
        //    return _mapper.Map<AccountDto>(entity);
        //}

        /////TODO : Update, Delete

        //private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    if (password == null)
        //        throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace, only string.", "password");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace, only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid lenght of password hash (64 bytes expected).", "password");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt(128 bytes expected.", "passwordSalt");
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }


    }
}
