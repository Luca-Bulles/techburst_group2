using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace techburst_group2.Controllers
{
    public class ModeratorController : Controller
    {
        [Authorize(Roles="User")]

        public IActionResult Index()
        {
            //var all = _coll.GetUsers();
            //userviews = new List<UserViewModel>();

            //foreach (var user in all)
            //{
            //    var viewmodel = ViewModelConverter.ConvertModelToUserViewModel(user);
            //    userviews.Add(viewmodel);
            //}
            return View();
        }
    }
}
