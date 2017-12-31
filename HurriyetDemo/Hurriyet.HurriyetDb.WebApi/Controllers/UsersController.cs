﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hurriyet.HurriyetDb.Business.Abstract;
using HurriyetDemo.HurriyetDb.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hurriyet.HurriyetDb.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUSerService _uSerService;

        public UsersController(IUSerService userService)
        {
            userService = _uSerService;
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
                _uSerService.Add(user);

                return new StatusCodeResult(201);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}