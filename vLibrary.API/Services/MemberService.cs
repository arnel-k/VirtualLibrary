using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using vLibrary.Api.Database;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API.Services
{
    public class MemberService : BaseCrudService<MemberDto, MemberSearchRequest, Member, MemberUpsertRequests, MemberUpsertRequests>, ICRUDService<MemberDto, MemberSearchRequest, MemberUpsertRequests, MemberUpsertRequests>
    {
        public MemberService(IMemberRepository<Member> repo, IMapper mapper) : base(repo, mapper)
        {
            ///TODO: Finish service 
        }
    }
}
