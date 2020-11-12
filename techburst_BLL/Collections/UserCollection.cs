using System;
using System.Collections.Generic;
using System.Text;
using Factories;
using techburst_BLL.Models;
using techburst_BLL.Utilities;

namespace techburst_BLL.Collections
{
    public class UserCollection
    {
        private List<UserModel> _users;

        public void Create(UserModel model)
        {
            var dto = ModelConverter.ConvertUserModelToDto(model);
            DalFactory.UserHandler.Create(dto);
        }

        public bool Login(UserModel model)
        {
            var dto = ModelConverter.ConvertUserModelToDto(model);
            return DalFactory.UserHandler.Login(dto);
        }

        public UserModel GetUserFromEmail(string email)
        {
            var model = ModelConverter.ConvertUserDtoToModel(DalFactory.UserHandler.GetUserFromEmail(email));
            return model;
        }
    }
}
