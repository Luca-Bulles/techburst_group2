﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using techburst_group2.Models;

namespace techburst_group2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var data = GetArticleData();
            ViewData["Articles"] = data;
            return View();
        }

        public IActionResult ArticleCard() =>
            new PartialViewResult
            {
                ViewName = "_ArticleCard"
            };

        //Move this to business logic layer in a later iteration pls :)
        public List<ArticleModel> GetArticleData()
        {
            List<ArticleModel> articles = new List<ArticleModel>();
            for (int i = 0; i < 9; i++)
            {
                ArticleModel article = new ArticleModel("test", "testbody", "Calin Peters");
                articles.Add(article);

            }

            return articles;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Articles()
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
