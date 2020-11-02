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
    public class ArticleController : Controller
    {
        private ArticleCollection _artColl;
        private List<ArticleModel> _articles;
        private List<TagDto> _tags;

        public ArticleController()
        {
            _artColl = new ArticleCollection();
            _articles = new List<ArticleModel>();
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

        public List<TagModel> GetAllTags()
        {
            _tags = DalFactory.CategoryHandler.GetAllTags();
            List<TagModel> tagViewModels = new List<TagModel>();

            foreach (var dto in _tags)
            {
                TagModel tag = new TagModel()
                {
                    Id = dto.Id,
                    Name = dto.Name
                };

                tagViewModels.Add(tag);
            }
            return tagViewModels;
        }

        public List<ArticleModel> GetArticlesByTag(int tagId)
        {
            var result = _artColl.GetArticlesByTag(tagId);

            foreach (var model in result)
            {
                ArticleModel viewModel = new ArticleModel() { Id = model.Id, Author = model.Author, Title = model.Title, Content = model.ArticleText, Tags = model.Categories, CreatedAt = model.DateCreated, LastEdited = model.LastEdited };
                _articles.Add(viewModel);
            }

            return _articles;
        }

                public IActionResult ArticlePage(int id)
        {
            var article = _coll.GetArticleById(id);
            ArticleModel articleModel = new ArticleModel() { Title = article.Title, Content = article.ArticleText, Tags = article.Categories };
            return View(articleModel);
        }
    }
}
