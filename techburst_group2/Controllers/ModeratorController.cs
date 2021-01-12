using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using techburst_BLL;
using techburst_BLL.Collections;
using techburst_BLL.Models;
using techburst_group2.Models;
using techburst_group2.Utilities;

namespace techburst_group2.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class ModeratorController : Controller
    {
        UserCollection _userCollection = new UserCollection();
        List<UservViewModel> userviews = new List<UservViewModel>();
        ArticleCollection articleCollection = new ArticleCollection();
        List<Models.ArticleModel> articles = new List<Models.ArticleModel>();

        public ModeratorController()
        {
            _userCollection = new UserCollection();
            articleCollection = new ArticleCollection();
        }
        public IActionResult Index()
        {
            var all = _userCollection.GetUsers();
            userviews = new List<UservViewModel>();

            foreach (var person in all)
            {
                userviews.Add(new UservViewModel
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
            TempData["Delete"] = "The records has been deleted from the system!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int ID)
        {
            var result = _userCollection.GetUsers();
            foreach (var user in result)
            {
                //when the ID's are equal. This ID's will be chosen, and all the information that carries with the ID will be writen.
                if (ID == user.UserId)
                {
                    var uservm = new UservViewModel()
                    {
                        ID = user.UserId,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = user.Password,
                        Role = user.Role
                    };

                    return View(uservm);
                }
            }
            return View();
        }


        [HttpPost]
        public ActionResult Edit(UservViewModel model)
        {
            var result = ViewModelConverter.ConvertUserViewModelToModel(model);
            _userCollection.Edit(result);
            TempData["Update"] = "The record has been changed from the system!";
            return RedirectToAction("Index", "Moderator");
        }

        //public IActionResult ArticleIndex()
        //{
        //    var all = articleCollection.GetAllArticles();
        //    articles = new List<Models.ArticleModel>();

        //    foreach (var person in all)
        //    {
        //        userviews.Add(new UservViewModel
        //        {
        //            ID = person.UserId,
        //            FirstName = person.FirstName,
        //            LastName = person.LastName,
        //            Email = person.Email,
        //            Password = person.Password,
        //            Role = person.Role
        //        });
        //    }

        //    return View(userviews);
        //}
    }
}
