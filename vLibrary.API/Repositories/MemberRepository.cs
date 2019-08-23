using vLibrary.Api.Database;
using vLibrary.API.Context;
using vLibrary.API.Repositories.Interfaces;

namespace vLibrary.API.Repositories
{
    public class MemberRepository: Repository<Member>, IMemberRepository<Member>
    {
        public MemberRepository(LibraryContext ctx): base(ctx)
        {

        }

       
    }
}
