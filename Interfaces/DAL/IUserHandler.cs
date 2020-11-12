using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;

namespace Interfaces.DAL
{
    public interface IUserHandler : IHandler<UserDto>
    {
        public bool Login(UserDto dto);

        public UserDto GetUserFromEmail(string email);
        public bool CheckIfEmailExists(string email);
    }
}
