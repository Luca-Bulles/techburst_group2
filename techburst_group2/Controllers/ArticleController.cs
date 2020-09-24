using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace techburst_group2.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Article(int id)
        {
            return View();
        }

        public IActionResult CreateArticle()
        {
            return View();
        }

        public IActionResult EditArticle(int id)
        {
            return View();
        }

        public IActionResult DeleteArticle(int id)
        {
            return View();
        }
    }
}
