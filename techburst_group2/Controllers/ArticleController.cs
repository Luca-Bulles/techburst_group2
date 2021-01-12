using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using techburst_BLL;
using techburst_BLL.Collections;
using techburst_group2.Utilities;

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
            UserCollection userColl = new UserCollection();
            var author = userColl.GetByID(article.AuthorId);
            Models.ArticleModel articleModel = new Models.ArticleModel()
            {
                Title = article.Title, Content = ArticleTextManager.DecodeArticleText(article.ArticleText),
                Images = article.Images,
                Author = author.FirstName + " " + author.LastName
            };
            return View(articleModel);
        }
    }
}
