using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hurriyet.HurriyetDb.Business.Abstract;
using HurriyetDemo.HurriyetDb.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Hurriyet.HurriyetDb.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private IUSerService _userService;

        public UsersController(IUSerService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _userService.GetAll();
                if (users == null || !users.Any())
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }
                _userService.Add(user);

                return new StatusCodeResult(201);
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                return new StatusCodeResult(500);
            }
        }
    }
}