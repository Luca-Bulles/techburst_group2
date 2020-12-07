using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;
using Factories;
using techburst_BLL.Models;
using techburst_BLL.Utilities;

namespace techburst_BLL.Collections
{
    public class UserCollection
    {
        private List<UserModel> user;

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

        public List<UserModel> GetUsers()
        {
            var result = DalFactory.UserHandler.GetAll();
            user = new List<UserModel>();

            foreach (var dto in result)
            {
                var model = ModelConverter.ConvertUserDtoToModel(dto);
                user.Add(model);
            }
            return user;
        }
        public void Delete(int ID)
        {
            DalFactory.UserHandler.Delete(ID);
        }

        public void Edit(UserModel Edit)
        {
            var DTO = ModelConverter.ConvertUserModelToDto(Edit);
            DalFactory.UserHandler.Update(DTO);

        }

        public UserModel GetByID(int ID)
        {
            var result = GetUsers();
            UserModel user = null;
            foreach (var item in result)
            {
                if (item.UserId == ID)
                {
                    user = item;
                }
            }
            return user;
        }
    }
}
