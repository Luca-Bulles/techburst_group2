using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using techburst_BLL;
using techburst_group2.Models;

namespace techburst_group2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ArticleCollection _coll;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _coll = new ArticleCollection();
        }

        public IActionResult Index()
        {
            var data = _coll.GetAllArticles();
            ViewData["Articles"] = data;
            return View();
        }

        public IActionResult ArticleCard() =>
            new PartialViewResult
            {
                ViewName = "_ArticleCard"
            };


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
