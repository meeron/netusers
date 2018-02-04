using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using web.domain.Models;

namespace web.Controllers.Api
{
    [Route("api/groups")]
    public class GroupsController : Controller
    {
        private static readonly List<Group> _groups = new List<Group>();

        [HttpGet("")]
        public IEnumerable<Group> Get()
        {
            return _groups;
        }

        [HttpPut("")]
        public IActionResult Save([FromBody] Group newGroup)
        {
            if (string.IsNullOrWhiteSpace(newGroup?.Name))
                return BadRequest();

            newGroup.Id = Guid.NewGuid().ToString();
            _groups.Add(newGroup);

            return StatusCode(201, newGroup);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var group = _groups.SingleOrDefault(g => g.Id == id);
            if (group == null)
                return NotFound();

            _groups.Remove(group);

            return Ok();
        }
    }
}