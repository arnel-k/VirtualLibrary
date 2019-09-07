using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vLibrary.API.Services;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API.Controllers
{
    public class MemberController : BaseCRUDController<MemberDto, MemberSearchRequest, MemberUpsertRequests, MemberUpsertRequests>
    {
        public MemberController(ICRUDService<MemberDto, MemberSearchRequest, MemberUpsertRequests, MemberUpsertRequests> service) : base(service)
        {
        }
    }
}