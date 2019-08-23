using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Api.Database;


namespace vLibrary.API.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> Get();
        //Model.Member Insert(Model.Requests.MemberInsertRequest request);
    }
}
