using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Entities.DTO;
using Entities.Enums;
using Factories;
using Interfaces.BLL;
using Microsoft.AspNetCore.Mvc;
using techburst_BLL;
using techburst_BLL.Collections;
using techburst_group2.Models;
using techburst_group2.Utilities;

namespace techburst_group2.Controllers
{
    public class ArticlesController : Controller
    {
        private ArticleCollection _artColl;
        private List<Models.ArticleModel> _articles;
        private List<TagDto> _tags;
        private IArticleModel _article;
        private ITagCollection _tagColl;

        public ArticlesController(IArticleModel article, ITagCollection tagColl)
        {
            _artColl = new ArticleCollection();
            _articles = new List<Models.ArticleModel>();
            _tags = new List<TagDto>();
            _article = article;
            _tagColl = tagColl;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Article(int id)
        {
            return View();
        }

        public void Submit(Models.ArticleModel article)
        {
            _article.Author = article.Author;
            _article.DateCreated = article.CreatedAt;
            _article.ArticleText = article.Content;
            _article.Title = article.Title;
            _article.Images = article.Images;
            _article.LastEdited = article.LastEdited;
            _article.TagID = _tagColl.GetByName(article.TagName).Id;
            _article.Draft = article.Draft;

                _artColl.Create(_article);
             RedirectToAction("index");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }


        public List<Models.ArticleModel> GetArticlesByTag(int tagId)
        {
            var result = _artColl.GetArticlesByTag(tagId);

            foreach (var model in result)
            {
                Models.ArticleModel viewModel = new Models.ArticleModel() { Id = model.Id, Author = model.Author, Title = model.Title, Content = model.ArticleText, TagName = model.TagName, CreatedAt = model.DateCreated, LastEdited = model.LastEdited };
                _articles.Add(viewModel);
            }

            return _articles;
        }
    }
}
