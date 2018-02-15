using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using web.business.Dto;

namespace web.Controllers.Api
{
    [Route("api/groups")]
    public class GroupsController : Controller
    {
        [HttpGet("")]
        public IEnumerable<GroupDto> Get()
        {
            return Enumerable.Empty<GroupDto>();
        }

        [HttpPut("")]
        public IActionResult Save([FromBody] GroupDto newGroup)
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