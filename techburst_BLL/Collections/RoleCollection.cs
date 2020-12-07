using System;
using System.Collections.Generic;
using System.Text;
using Factories;
using techburst_BLL.Models;
using techburst_BLL.Utilities;
using techburst_DAL.Handler;

namespace techburst_BLL.Collections
{
    public class RoleCollection
    {
        private List<RoleModel> _roles;

        public RoleModel GetRole(int id)
        {
            return ModelConverter.ConvertRoleDtoToModel(
                DalFactory.RoleHandler.GetRoleFromId(DalFactory.RoleHandler.GetRoleFromUser(id)));
        }
    }
}
