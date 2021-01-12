using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using techburst_BLL.Collections;
using techburst_BLL.Models;
using techburst_group2.Models;

namespace techburst_group2.Controllers
{
    public class UserController : Controller
    {
        UserCollection _userCollection = new UserCollection();
        private List<LoginViewmodel> LVM;

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            TempData["UserLogout"] = "You have logged out!";
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewmodel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = new UserModel()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    Role = model.Role
                    
                };
                _userCollection.Create(user);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind] UserModel model)
        {
            
            if (ModelState.IsValid)
            {
                var result = _userCollection.Login(model);

                if (result)
                {
                    LVM = new List<LoginViewmodel>();
                    UserModel user = _userCollection.GetUserFromEmail(model.Email);
                    if (user.Email == model.Email)
                    {
                        LVM.Add(new LoginViewmodel
                        {
                            Email = user.Email,
                            Password = user.Password,
                            Role = user.Role

                        });

                        var claims = new List<Claim>
                                {
                                    new Claim(ClaimTypes.Email, model.Email),
                                    new Claim(ClaimTypes.Role, user.Role),
                                    new Claim("fullname",user.FirstName + " " + user.LastName)
                                };
                        ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        await HttpContext.SignInAsync(principal);
                        TempData["LoggedIn"] = "You have logged in with your personal account.";
                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    
}
