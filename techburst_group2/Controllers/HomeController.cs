using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using techburst_BLL;
using techburst_group2.Models;

namespace techburst_group2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<ArticleModel> _articles;
        private ArticleCollection _coll;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _coll = new ArticleCollection();
            _articles = new List<ArticleModel>();
        }

        public IActionResult Index()
        {
            var data = _coll.GetAllArticles();
            foreach (var unconvertedArticle in data)
            {
                ArticleModel viewModel = new ArticleModel() {Id = unconvertedArticle.Id, Author = unconvertedArticle.Author, Title = unconvertedArticle.Title, Content = unconvertedArticle.ArticleText, Tags = unconvertedArticle.Categories, CreatedAt = unconvertedArticle.DateCreated, LastEdited = unconvertedArticle.LastEdited};
                _articles.Add(viewModel);

            }
            ViewData["Articles"] = _articles;
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

        public IActionResult ArticlePage(int id)
        {
            var article = _coll.GetArticleById(id);
            ArticleModel articleModel = new ArticleModel() { Content = article.ArticleText };
            return View(articleModel);
        }

        public IActionResult Articles() 
        {
            var data = _coll.GetAllArticles();
            foreach (var unconvertedArticle in data)
            {
                ArticleModel viewModel = new ArticleModel() { Id = unconvertedArticle.Id, Author = unconvertedArticle.Author, Title = unconvertedArticle.Title, Content = unconvertedArticle.ArticleText, Tags = unconvertedArticle.Categories, CreatedAt = unconvertedArticle.DateCreated, LastEdited = unconvertedArticle.LastEdited };
                _articles.Add(viewModel);

            }

            return View(_articles);
        }

        public IActionResult AddArticle() 
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
