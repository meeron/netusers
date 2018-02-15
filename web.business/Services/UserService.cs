using System;
using System.Collections.Generic;
using System.Linq;
using web.business.Dto;
using web.domain.Models;
using web.domain.Repositories;

namespace web.business.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _repository;

        public UserService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserDto> Get()
        {
            return _repository.Find().Select(Map);
        }

        private static UserDto Map(User user)
        {
            return new UserDto
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Email = user.Email 
            };
        }
    }
}