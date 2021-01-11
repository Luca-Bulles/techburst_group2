using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using techburst_BLL;
using techburst_group2.Utilities;

namespace techburst_group2.Controllers
{
    public class ArticleController : Controller
        
    {
        List<Models.ArticleModel> model = new List<Models.ArticleModel>();
        private readonly ArticleCollection _articleColl;
        public ArticleController()
        {
            _articleColl = new ArticleCollection();
        }

        public ActionResult ArticlePage(int id)
        {
            if (id != 0)
            {
                var article = _articleColl.GetArticleById(id);

                Models.ArticleModel articleModel = new Models.ArticleModel()
                {
                    Title = article.Title,
                    Content = ArticleTextManager.DecodeArticleText(article.ArticleText),
                    Images = article.Images
                };
                model.Add(articleModel);

                return View(model);
            }
            else
            {
                return Content("<script>console.log('Id cannot be 0!');</script>") ;
            }
        }
    }
}
