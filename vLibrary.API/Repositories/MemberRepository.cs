using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.API.Context;
using vLibrary.API.Dtos;
using vLibrary.API.Repositories.Interfaces;
using vLibrary.Model;

namespace vLibrary.API.Repositories
{
    public class MemberRepository: Repository<Member>, IMemberRepository<Member>
    {
        public MemberRepository(LibraryContext ctx): base(ctx)
        {

        }

       
    }
}
