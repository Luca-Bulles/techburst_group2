using System;
using System.Collections.Generic;
using Entities.Enums;
using Factories;
using Interfaces.BLL;
using techburst_BLL.Utilities;
using techburst_Data_Access_Layer.DTO;

namespace techburst_BLL
{
    public class ArticleCollection : IArticleCollection
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
            List<ArticleDto> result = DalFactory.ArticleHandler.GetAll();
            _articles = new List<IArticleModel>();

            foreach (var dto in result)
            {
                var model = ModelConverter.ConvertDtoToModel(dto);
                _articles.Add(model);
            }

            return _articles;
        }

        public List<IArticleModel> GetArticlesByTag(int tagId)
        {
            List<ArticleDto> dtoList = DalFactory.ArticleHandler.GetArticlesByTag(tagId);

            foreach (var dto in dtoList)
            {
                var richModel = ModelConverter.ConvertDtoToModel(dto);
                _articles.Add(richModel);
            }

            return _articles;
        }

        public IArticleModel GetArticleById(int id)
        {
            IArticleModel article = null;
            _articles = GetAllArticles();
            foreach (var art in _articles)
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
