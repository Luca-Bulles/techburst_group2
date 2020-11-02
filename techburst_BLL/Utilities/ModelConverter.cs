using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;
using techburst_Data_Access_Layer.DTO;

namespace techburst_BLL.Utilities
{
    public static class ModelConverter
    {
        private static ArticleModel _model;
        private static ArticleDto _dto;
        public static ArticleModel ConvertDtoToModel(ArticleDto dto)
        {
            _model = new ArticleModel()
            {
                Id = dto.ArticleID, Title = dto.Title, ArticleText = dto.ArticleText, CategoryId = dto.Categories, DateCreated = dto.DateCreated, Draft = dto.Draft, Images = dto.Images, LastEdited = dto.LastEdited
            };

            return _model;
        }

        public static ArticleDto ConvertModelToDto(ArticleModel model)
        {
            _dto = new ArticleDto() {ArticleID = model.Id, Title = model.Title, ArticleText = model.ArticleText, Categories = model.CategoryId, DateCreated = model.DateCreated, Draft = model.Draft, Images = model.Images, LastEdited = model.LastEdited};
            return _dto;
        }
    }
}
