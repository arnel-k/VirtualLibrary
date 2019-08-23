using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Api.Database;
using vLibrary.API.Repositories;
using vLibrary.API.Repositories.Interfaces;



namespace vLibrary.API.Services
{
    public class MemberService : IMemberService
    {
        //private readonly LibraryContext _ctx;
        //public MemberService(LibraryContext ctx)
        //{
        //    _ctx = ctx;
        //}
        private readonly IMemberRepository<Member> _repo;
        public MemberService(IMemberRepository<Member> repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<Member>> Get()
        {
            return await _repo.GetAll();
            
        }

        //public Model.Member Insert(MemberInsertRequest request)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
