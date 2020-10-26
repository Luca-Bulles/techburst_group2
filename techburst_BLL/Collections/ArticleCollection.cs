using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Enums;
using Factories;
using techburst_BLL.Utilities;

namespace techburst_BLL
{
    public class ArticleCollection
    {
        private List<Article> _articles;

        //@TODO: Add validation for user type in later iteration.

        public void Create(Article article)
        {
            var result = ModelConverter.ConvertModelToDto(article);
            DalFactory.ArticleHandler.Create(result);
        }

        public List<Article> GetAllArticles()
        {
            var result = DalFactory.ArticleHandler.GetAll();
            _articles = new List<Article>();

            foreach (var dto in result)
            {
                var model = ModelConverter.ConvertDtoToModel(dto);
                model.Categories.Add(model.GetCategory(model.CategoryId));
                _articles.Add(model);
            }

            return _articles;
        }

        public Article GetArticleById(int articleId)
        {
            Article article = null;
            var articles = GetAllArticles();
            for (int i = 0; i < articles.Count; i++)
            {
                if (articles[i].Id == articleId)
                {
                    article = new Article() {Id = articles[i].Id, Author = articles[i].Author, Title = articles[i].Title, ArticleText = articles[i].ArticleText, Categories = articles[i].Categories, DateCreated = articles[i].DateCreated, Draft = articles[i].Draft, Images = articles[i].Images, LastEdited = articles[i].LastEdited};
                }
            }
            return article;
        }

        public List<Article> GetArticlesByTag(int tagId)
        {
            var dtoList = DalFactory.ArticleHandler.GetArticlesByTag(tagId);

            foreach (var dto in dtoList)
            {
                var richModel = ModelConverter.ConvertDtoToModel(dto);
                _articles.Add(richModel);
            }

            return _articles;
        }
    }
}
