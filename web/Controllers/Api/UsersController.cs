using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using web.domain.Models;

namespace web.Controllers.Api
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private static readonly List<User> _users = new List<User>
        {
            NewUser("Obi Wan", "obi.wan@jedi.com"),
            NewUser("Darth Maul", "darth.maul@sith.com")
        };

        [HttpGet("")]
        public IEnumerable<User> Get()
        {
            return _users;
        }

        [HttpPut("")]
        public IActionResult Save([FromBody] User newUser)
        {
            if (!(newUser?.IsValid()).GetValueOrDefault())
                return BadRequest();

            newUser.Id = Guid.NewGuid().ToString();
            _users.Add(newUser);

            return StatusCode(201, newUser);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            _users.Remove(user);

            return Ok();
        }

        private static User NewUser(string name, string email)
        {
            return new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Email = email
            };
        }
    }
}