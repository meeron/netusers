using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using web.business.Services;
using web.business.Dto;

namespace web.Controllers.Api
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IEnumerable<UserDto> Get()
        {
            return _service.Get();
        }

        [HttpPut("")]
        public IActionResult Save([FromBody] UserDto newUser)
        {
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return BadRequest();
        }
    }
}