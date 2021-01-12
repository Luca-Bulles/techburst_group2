using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Enums;
using Interfaces.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using techburst_BLL;
using techburst_BLL.Collections;
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
        private ContactCollection contactCollection;

        private readonly ContactCollection _contact;

        public HomeController(ILogger<HomeController> logger, IArticleCollection articleColl, ContactCollection _contactCollection)
        {
            _logger = logger;
            _coll = new ArticleCollection();
            _articles = new List<Models.ArticleModel>();
            _articlelogic = new techburst_BLL.ArticleModel();
            _articleColl = articleColl;
            contactCollection = _contactCollection;
          
        }

        public IActionResult Index(string SearchText)
        {
            var data = _coll.GetAllArticles();
            if (!string.IsNullOrEmpty(SearchText))
            {
                string text = SearchText.ToUpper();
                var result = data.Where(a => a.Title.Contains(text));
                UserCollection userColl = new UserCollection();
                foreach (var unconvertedArticle in result)
                {
                    var author = userColl.GetByID(unconvertedArticle.AuthorId);
                    Models.ArticleModel viewModel = new Models.ArticleModel() { Id = unconvertedArticle.Id, Author = author.FirstName + " " + author.LastName, Title = unconvertedArticle.Title, Content = ArticleTextManager.DecodeArticleText(unconvertedArticle.ArticleText), TagID = unconvertedArticle.TagID, CreatedAt = unconvertedArticle.DateCreated, LastEdited = unconvertedArticle.LastEdited, Images = unconvertedArticle.Images };
                    _articles.Add(viewModel);

                }
                ViewData["Articles"] = _articles;
                return View();
            }
            else
            {
                UserCollection userColl = new UserCollection();
                foreach (var unconvertedArticle in data)
                {
                    var author = userColl.GetByID(unconvertedArticle.AuthorId);
                    Models.ArticleModel viewModel = new Models.ArticleModel() { Id = unconvertedArticle.Id, Author = author.FirstName + " " + author.LastName, Title = unconvertedArticle.Title, Content = ArticleTextManager.DecodeArticleText(unconvertedArticle.ArticleText), TagID = unconvertedArticle.TagID, CreatedAt = unconvertedArticle.DateCreated, LastEdited = unconvertedArticle.LastEdited, Images = unconvertedArticle.Images };
                    _articles.Add(viewModel);

                }
                ViewData["Articles"] = _articles;
                return View();
            }
        }

            public ActionResult Searchresult(string SearchText)
            {
                var data = _coll.GetAllArticles();
                if (!string.IsNullOrEmpty(SearchText))
                {
                    string text = SearchText.ToUpper();
                    var result = data.Where(a => a.Title.Contains(text));
                    foreach (var unconvertedArticle in result)
                    {
                        Models.ArticleModel viewModel = new Models.ArticleModel() { Id = unconvertedArticle.Id, Author = unconvertedArticle.Author, Title = unconvertedArticle.Title, Content = ArticleTextManager.DecodeArticleText(unconvertedArticle.ArticleText), TagID = unconvertedArticle.TagID, CreatedAt = unconvertedArticle.DateCreated, LastEdited = unconvertedArticle.LastEdited, Images = unconvertedArticle.Images };
                        _articles.Add(viewModel);

                    }
                    ViewData["Articles"] = _articles;
                    return View();
                }
                else
                {
                    foreach (var unconvertedArticle in data)
                    {
                        Models.ArticleModel viewModel = new Models.ArticleModel() { Id = unconvertedArticle.Id, Author = unconvertedArticle.Author, Title = unconvertedArticle.Title, Content = ArticleTextManager.DecodeArticleText(unconvertedArticle.ArticleText), TagID = unconvertedArticle.TagID, CreatedAt = unconvertedArticle.DateCreated, LastEdited = unconvertedArticle.LastEdited, Images = unconvertedArticle.Images };
                        _articles.Add(viewModel);

                    }
                    ViewData["Articles"] = _articles;
                    return View();
                }
            }
        

        public IActionResult AdminIndex()
        {
            var data = _coll.GetAllArticles();
            var articles = new List<Models.ArticleModel>();
            UserCollection userColl = new UserCollection();

            foreach (var unconvertedArticle in data)
            {
                var author = userColl.GetByID(unconvertedArticle.AuthorId);

                articles.Add(new Models.ArticleModel

                { Id = unconvertedArticle.Id,
                    Author = author.FirstName + " " + author.LastName,
                    Title = unconvertedArticle.Title,
                    Content = ArticleTextManager.DecodeArticleText(unconvertedArticle.ArticleText), 
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


        public IActionResult Articles(List<Models.ArticleModel> articles) 
        {
            return View(articles);
        }

        public IActionResult LoadAllArticles() {

            var data = _coll.GetAllArticles();
            UserCollection userColl = new UserCollection();
            foreach (var unconvertedArticle in data)
            {
                var author = userColl.GetByID(unconvertedArticle.AuthorId);
                Models.ArticleModel viewModel = new Models.ArticleModel() { Id = unconvertedArticle.Id, Author = author.FirstName + " " + author.LastName, Title = unconvertedArticle.Title, Content = ArticleTextManager.DecodeArticleText(unconvertedArticle.ArticleText), TagID = unconvertedArticle.TagID, CreatedAt = unconvertedArticle.DateCreated, LastEdited = unconvertedArticle.LastEdited, Images = unconvertedArticle.Images };
                _articles.Add(viewModel);

            }
            _articles.Reverse();
            return View("../Home/Articles", _articles);
        }

        public IActionResult LoadArticlesByTag(int tagId) {
            var data = _coll.GetArticlesByTag(tagId);
            UserCollection userColl = new UserCollection();
            
            foreach (var unconvertedArticle in data)
            {
                var author = userColl.GetByID(unconvertedArticle.AuthorId);
                Models.ArticleModel viewModel = new Models.ArticleModel() { Id = unconvertedArticle.Id, Author = author.FirstName + " " + author.LastName, Title = unconvertedArticle.Title, Content = ArticleTextManager.DecodeArticleText(unconvertedArticle.ArticleText), TagID = unconvertedArticle.TagID, CreatedAt = unconvertedArticle.DateCreated, LastEdited = unconvertedArticle.LastEdited, Images = unconvertedArticle.Images };
                _articles.Add(viewModel);

            }
            _articles.Reverse();
            return View("../Home/Articles", _articles);
        }

        [Authorize(Roles ="Moderator")]
        public ActionResult Delete(int ID)
        {
            _articlelogic.Delete(ID);
            TempData["Delete"] = "This has been deleted!";
            return RedirectToAction("Index");
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
