using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;

namespace Interfaces.DAL
{
    public interface IRoleHandler : IHandler<RoleDto>
    {
        public void AddUserToRole(RoleDto role, UserDto user);
        public void RemoveUserFromRole(RoleDto role, UserDto user);
        public RoleDto GetRoleFromId(int id);
        public int GetRoleFromUser(int id);
    }
}
