using System;
using System.Collections.Generic;
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

            foreach (var dto in result)
            {
                var model = ModelConverter.ConvertDtoToModel(dto);
                model.Categories.Add(model.GetCategory(model.CategoryId));
                _articles = new List<Article>() { model };
            }

            return _articles;
        }
    }
}
