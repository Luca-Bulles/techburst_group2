﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Enums;
using Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using techburst_BLL;
using techburst_group2.Models;
using techburst_group2.Utilities;

namespace techburst_group2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Models.ArticleModel> _articles;
        private ArticleCollection _coll;
        private techburst_BLL.ArticleModel _articlelogic;
        private IArticleCollection _articleColl;

        public HomeController(ILogger<HomeController> logger, IArticleCollection articleColl)
        {
            _logger = logger;
            _coll = new ArticleCollection();
            _articles = new List<Models.ArticleModel>();
            _articlelogic = new techburst_BLL.ArticleModel();
            _articleColl = articleColl;
        }

        public IActionResult Index()
        {
            var data = _coll.GetAllArticles();
            foreach (var unconvertedArticle in data)
            {
                Models.ArticleModel viewModel = new Models.ArticleModel() { Id = unconvertedArticle.Id, Author = unconvertedArticle.Author, Title = unconvertedArticle.Title, Content = unconvertedArticle.ArticleText, TagID = unconvertedArticle.TagID, CreatedAt = unconvertedArticle.DateCreated, LastEdited = unconvertedArticle.LastEdited, Images = unconvertedArticle.Images };
                _articles.Add(viewModel);

            }
            ViewData["Articles"] = _articles;
            return View();
        }

        public IActionResult AdminIndex()
        {
            var data = _coll.GetAllArticles();
            var articles = new List<Models.ArticleModel>();
            foreach (var unconvertedArticle in data)
            {
              articles.Add(new Models.ArticleModel

                { Id = unconvertedArticle.Id, 
                    Author = unconvertedArticle.Author, 
                    Title = unconvertedArticle.Title,
                    Content = unconvertedArticle.ArticleText, 
                    TagID = unconvertedArticle.TagID, 
                    CreatedAt = unconvertedArticle.DateCreated, 
                    LastEdited = unconvertedArticle.LastEdited
               });
            }
            return View(articles);
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

        //Vanaf hier nog in articles controller verplaatsen
        public IActionResult Articles(List<Models.ArticleModel> articles) 
        {
            return View(articles);
        }

        public IActionResult LoadAllArticles() {
            var data = _coll.GetAllArticles();
            foreach (var unconvertedArticle in data)
            {
                Models.ArticleModel viewModel = new Models.ArticleModel() { Id = unconvertedArticle.Id, Author = unconvertedArticle.Author, Title = unconvertedArticle.Title, Content = unconvertedArticle.ArticleText, TagID = unconvertedArticle.TagID, CreatedAt = unconvertedArticle.DateCreated, LastEdited = unconvertedArticle.LastEdited, Images = unconvertedArticle.Images };
                _articles.Add(viewModel);
            }

            return Articles(_articles);
        }

        public IActionResult GetArticlesByTag(int tagId)
        {
            var result = _coll.GetArticlesByTag(tagId);

            foreach (var model in result)
            {
                Models.ArticleModel viewModel = new Models.ArticleModel() { Id = model.Id, Author = model.Author, Title = model.Title, Content = model.ArticleText, TagName = model.TagName, CreatedAt = model.DateCreated, LastEdited = model.LastEdited };
                _articles.Add(viewModel);
            }

            return Articles(_articles);
        }
        //tot hier

        public ActionResult Delete(int ID)
        {
            _articlelogic.Delete(ID);
            return RedirectToAction("Index");
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
