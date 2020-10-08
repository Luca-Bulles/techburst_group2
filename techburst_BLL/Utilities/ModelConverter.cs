using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;
using techburst_Data_Access_Layer.DTO;

namespace techburst_BLL.Utilities
{
    public static class ModelConverter
    {
        private static Article _model;
        private static ArticleDto _dto;
        public static Article ConvertDtoToModel(ArticleDto dto)
        {
            _model = new Article()
            {
                Id = dto.ArticleID, Title = dto.Title, ArticleText = dto.ArticleText, Categories = Enum.Parse<Category>(dto.Categories), Tags = Enum.Parse<Tag>(dto.Tags), DateCreated = dto.DateCreated, Draft = dto.Draft, Images = dto.Images, LastEdited = dto.LastEdited
            };

            return _model;
        }

        public static ArticleDto ConvertModelToDto(Article model)
        {
            _dto = new ArticleDto() {ArticleID = model.Id, Title = model.Title, ArticleText = model.ArticleText, Categories = model.Categories.ToString(), Tags = model.Tags.ToString(), DateCreated = model.DateCreated, Draft = model.Draft, Images = model.Images, LastEdited = model.LastEdited};
            return _dto;
        }
    }
}
