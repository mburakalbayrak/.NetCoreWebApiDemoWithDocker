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

            [HttpPost("new")]
            public IActionResult GetToken([FromBody]User user)
            {
                //if (IsValidUserAndPassword(user.Username, user.Password))

                //if (ModelState.IsValid)
                //{
                //    return new ObjectResult(GenerateToken(user));
                //}
                if (IsValidUserAndPassword(user))
                {
                    return new ObjectResult(GenerateToken(user));
                }

                return Unauthorized();
            }

            private string GenerateToken(User user)
            {
                var someClaims = new Claim[]{
                    new Claim(JwtRegisteredClaimNames.UniqueName,user.Username),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.NameId,Guid.NewGuid().ToString())
                };

                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("uzun ince bir yoldayım şarkısını buradan tüm sevdiklerime hediye etmek istiyorum mümkün müdür acaba?"));
                var token = new JwtSecurityToken(
                    issuer: "balbayrak.com.tr",
                    audience: user.Email,
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
                        if (_userService.GetUser(user.Email, user.Password) != null)
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
