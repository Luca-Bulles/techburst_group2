using System;
using System.Collections.Generic;
using Entities.Enums;
using Factories;
using Interfaces.BLL;
using techburst_BLL.Utilities;

namespace techburst_BLL
{
    public class ArticleCollection
    {
        private List<IArticleModel> _articles;

        //@TODO: Add validation for user type in later iteration.

        public void Create(IArticleModel article)
        {
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
                //model.Categories.Add(model.GetCategory(model.CategoryId));
                _articles.Add(model);
            }

            return _articles;
        }

        public List<IArticleModel> GetArticlesByTag(int tagId)
        {
            var dtoList = DalFactory.ArticleHandler.GetArticlesByTag(tagId);

            foreach (var dto in dtoList)
            {
                var richModel = ModelConverter.ConvertDtoToModel(dto);
                _articles.Add(richModel);
            }

            return _articles;
        }

        public ArticleModel GetArticleById(int Id)
        {
            var article = DalFactory.ArticleHandler.GetById(Id);

            var richModel = ModelConverter.ConvertDtoToModel(article);

            return richModel;
        }
    }
}
