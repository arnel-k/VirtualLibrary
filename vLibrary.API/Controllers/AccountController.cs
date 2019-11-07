using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using vLibrary.API.Exceptions;
using vLibrary.API.Helpers;
using vLibrary.API.Services;
using vLibrary.Model;
using vLibrary.Model.Requests;

namespace vLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseCRUDController<AccountDto, AccountSearchRequest, AccountUpsertRequest, AccountUpsertRequest>
    {
        private readonly AppSettings _appSettings;
        private readonly IAccountService<AccountDto, AccountSearchRequest> _accountService;
        public AccountController(ICRUDService<AccountDto, AccountSearchRequest, AccountUpsertRequest, AccountUpsertRequest> service, IOptions<AppSettings> appSettings, IAccountService<AccountDto, AccountSearchRequest> accountService) : base(service)
        {
            _accountService = accountService;
            _appSettings = appSettings.Value;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AccountUpsertRequest request)
        {
            var account =  await _accountService.Authenticate(request.UserName, request.Password);
            
            if (account == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, account.Guid.ToString()),
                    new Claim(ClaimTypes.Role, account.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Username = account.Username,
                Role = account.Role,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AccountUpsertRequest request)
        {
            try
            {
                await _accountService.Insert(request);
                return Ok();
            }
            catch(UserException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
      
    }
}