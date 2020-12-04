using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using techburst_BLL.Collections;
using techburst_BLL.Models;
using techburst_group2.Models;

namespace techburst_group2.Controllers
{
    [Authorize(Roles = "User")]
    public class ModeratorController : Controller
    {
        UserCollection _userCollection = new UserCollection();
        List<RegisterViewmodel> userviews = new List<RegisterViewmodel>();
        public ModeratorController()
        {
            _userCollection = new UserCollection();
        }
        public IActionResult Index()
        {
            var all = _userCollection.GetUsers();
            userviews = new List<RegisterViewmodel>();

            foreach (var person in all)
            {
                userviews.Add(new RegisterViewmodel
                {
                    ID = person.UserId,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    Password = person.Password,
                    Role = person.Role
                });
             }
            
            return View(userviews);
        }
        public IActionResult Delete(int ID)
        {
            _userCollection.Delete(ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult Update()
        {
            var viewmodel = new RegisterViewmodel();
            var result = _userCollection.GetUserFromEmail(viewmodel.Email);
            return View(result);
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult Update(UserModel model)
        {
            _userCollection.Edit(model);
            TempData["Update"] = "The records has been changed from the system!";
            return RedirectToAction("Index", "Home");
        }
    }
}
