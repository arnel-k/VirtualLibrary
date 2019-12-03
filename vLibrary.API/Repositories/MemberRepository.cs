using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using vLibrary.Api.Database;
using vLibrary.API.Context;
using vLibrary.API.Repositories.Interfaces;

namespace vLibrary.API.Repositories
{
    public class MemberRepository: Repository<Member>, IMemberRepository<Member>
    {
        private readonly LibraryContext _ctx;
        public MemberRepository(LibraryContext ctx): base(ctx)
        {
            _ctx = ctx;
        }

        public override async Task<Member> GetById(Guid guid)
        {
            return await _ctx.Member.FirstOrDefaultAsync(x => x.Guid == guid);
        }

        public override void Delete(Member entity)
        {
            var member = _ctx.Member.Where(x => x.Id == entity.Id).Include(a => a.Account).FirstOrDefault();
            _ctx.Remove(member.Account);
            _ctx.Remove(member);
            _ctx.SaveChanges();
        }

    }
}
