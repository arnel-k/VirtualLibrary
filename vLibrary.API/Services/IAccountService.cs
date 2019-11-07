using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vLibrary.Api.Database;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API.Services
{
    public interface IAccountService<T, TSearch> : IService<T, TSearch> where T: class
    {
        Task<T> Authenticate(string username, string password);
        Task<T> Insert(AccountUpsertRequest insert);
    }
}
