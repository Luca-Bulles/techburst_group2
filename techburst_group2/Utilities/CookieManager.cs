using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using techburst_BLL.Collections;
using techburst_BLL.Models;
using techburst_group2.Models;

namespace techburst_group2.Utilities
{
    public class CookieManager
    {
        public static List<object> SetCookie(UserModel model)
        {
            var LVM = new List<LoginViewmodel>();
            UserCollection uCollection = new UserCollection();
            UserModel user = uCollection.GetUserFromEmail(model.Email);
            if (user.Email == model.Email)
            {
                LVM.Add(new LoginViewmodel
                {
                    Id = user.UserId,
                    Email = user.Email,
                    Password = user.Password,
                    Role = user.Role

                });

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("UserID", user.UserId.ToString())
                };
                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                return new List<object>()
                {
                    claims,
                    userIdentity,
                    principal
                };
            }

            return null;
        }
    }
}
