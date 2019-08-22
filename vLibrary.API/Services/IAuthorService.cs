using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Model;

namespace vLibrary.API.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> Get();
    }
}
