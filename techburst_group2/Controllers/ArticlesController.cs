using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Entities.DTO;
using Entities.Enums;
using Factories;
using Microsoft.AspNetCore.Mvc;
using techburst_BLL;
using techburst_BLL.Collections;
using techburst_group2.Models;

namespace techburst_group2.Controllers
{
    public class ArticlesController : Controller
    {
        private ArticleCollection _artColl;
        private List<Models.ArticleModel> _articles;
        private List<TagDto> _tags;

        public ArticlesController()
        {
            _artColl = new ArticleCollection();
            _articles = new List<Models.ArticleModel>();
            _tags = new List<TagDto>();
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
            techburst_BLL.ArticleModel model = new techburst_BLL.ArticleModel()
            {
                Author = article.Author,
                DateCreated = article.CreatedAt,
                ArticleText = article.Content,
                Title = article.Title,
                Images = article.Images,
                LastEdited = article.LastEdited,
                Categories = article.Tags,
                Draft = article.Draft

            };
            _artColl.Create(model);
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
                Models.ArticleModel viewModel = new Models.ArticleModel() { Id = model.Id, Author = model.Author, Title = model.Title, Content = model.ArticleText, Tags = model.Categories, CreatedAt = model.DateCreated, LastEdited = model.LastEdited };
                _articles.Add(viewModel);
            }

            return _articles;
        }
    }
}
