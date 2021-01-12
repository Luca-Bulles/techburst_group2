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
        private static List<Claim> _claims;
        private static ClaimsIdentity _identity;
        private static ClaimsPrincipal _principal;
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

                _claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("UserID", user.UserId.ToString())
                };
                _identity = new ClaimsIdentity(_claims, "login");
                _principal = new ClaimsPrincipal(_identity);

                return new List<object>()
                {
                    _claims,
                    _identity,
                    _principal
                };
            }

            return null;
        }

        public static int GetUserId()
        {
            var claim = _identity.FindFirst("UserID");
            return Convert.ToInt32(claim == null ? string.Empty : claim.Value);
        }
    }
}
