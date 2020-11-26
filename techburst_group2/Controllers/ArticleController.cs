﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using techburst_BLL;

namespace techburst_group2.Controllers
{
    public class ArticleController : Controller
        
    {
        private readonly ArticleCollection _articleColl;
        public ArticleController()
        {
            _articleColl = new ArticleCollection();
        }
        public IActionResult ArticlePage(int id)
        {
            var article = _articleColl.GetArticleById(id);
            Models.ArticleModel articleModel = new Models.ArticleModel() { Title = article.Title, Content = article.ArticleText, Images = article.Images };
            return View(articleModel);
        }
    }
}