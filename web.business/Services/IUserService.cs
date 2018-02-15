using System.Collections.Generic;
using web.business.Dto;

namespace web.business.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> Get();
    }
}