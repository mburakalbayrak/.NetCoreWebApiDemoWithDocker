using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hurriyet.HurriyetDb.Business.Abstract;

namespace Hurriyet.HurriyetDb.WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using HurriyetDemo.HurriyetDb.Entities.Concrete;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;

    namespace Hurriyet.HurriyetDb.WebApi.Controllers
    {
        [AllowAnonymous]
        [Route("api/token")]
        public class TokenController : Controller
        {
            private IUSerService _userService;

            public TokenController(IUSerService userService)
            {
                _userService = userService;
            }

            [HttpGet]
            public string Get()
            {
                return "send your username and password with post method";
            }

            [HttpPost("new")]
            public IActionResult GetToken([FromBody]User user)
            {
                if (IsValidUserAndPassword(user))
                {
                    return new ObjectResult(GenerateToken(user.UserName));
                }

                return Unauthorized();
            }

            private string GenerateToken(string userName)
            {
                var someClaims = new Claim[]{
                    new Claim(JwtRegisteredClaimNames.UniqueName,userName),
                    new Claim(JwtRegisteredClaimNames.Email,"heimdall@mail.com"),
                    new Claim(JwtRegisteredClaimNames.NameId,Guid.NewGuid().ToString())
                };

                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("şifrelenecek anahtar metin burada"));
                var token = new JwtSecurityToken(
                    issuer: "",
                    audience: "",
                    claims: someClaims,
                    expires: DateTime.Now.AddMinutes(3),
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            private bool IsValidUserAndPassword(User user)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (_userService.GetUser(user.UserName, user.Password) != null)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            }
        }
    }

}
