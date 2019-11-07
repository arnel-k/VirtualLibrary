using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vLibrary.Api.Database;

namespace vLibrary.API.Repositories.Interfaces
{
    public interface IAccountRepository<T> : IRepository<T> where T: class
    {
        new Task<Account> GetById(Guid guid);
    }
}
