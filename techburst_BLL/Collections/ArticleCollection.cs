using System;
using System.Collections.Generic;
using Entities.Enums;
using Factories;
using Interfaces.BLL;
using techburst_BLL.Utilities;

namespace techburst_BLL
{
    public class ArticleCollection : IArticleCollection
    {
        private List<IArticleModel> _articles;

        //@TODO: Add validation for user type in later iteration.

        public void Create(IArticleModel article)
        {
            article.ArticleText = article.ArticleText;
            var result = ModelConverter.ConvertModelToDto(article);
            DalFactory.ArticleHandler.Create(result);
        }

        public List<IArticleModel> GetAllArticles()
        {
            var result = DalFactory.ArticleHandler.GetAll();
            _articles = new List<IArticleModel>();

            foreach (var dto in result)
            {
                var model = ModelConverter.ConvertDtoToModel(dto);
                model.ArticleText = model.ArticleText;
                _articles.Add(model);
            }

            return _articles;
        }

        public List<IArticleModel> GetArticlesByTag(int tagId)
        {
            var modelList = GetAllArticles();

            foreach (var model in modelList)
            {
                if (model.TagID == tagId)
                {
                    _articles.Add(model);
                }
            }

            return _articles;
        }

        public IArticleModel GetArticleById(int id)
        {
            List<IArticleModel> articles = GetAllArticles();
            IArticleModel article = null;

            foreach (var art in articles)
            {
                if (art.Id == id)
                {
                    article = art;
                }
            }

            return article;
        }
    }
}
