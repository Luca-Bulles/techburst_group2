using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;
using Factories;
using techburst_BLL.Utilities;

namespace techburst_BLL
{
    public class ArticleModel
    {
        public List<Tag> Categories { get; set; }
        public int CategoryId { get; set; }
        public int Id { get; set; }
        public int Author { get; set; }
        public string Title { get; set; }
        public string ArticleText { get; set; }
        public DateTime DateCreated { get; set; }
        public double Draft { get; set; }
        public DateTime LastEdited { get; set; }
        public string Images { get; set; }
       
        public ArticleModel()
        {
            Categories = new List<Tag>();
        }

        public void Delete(int id)
        {
            DalFactory.ArticleHandler.Delete(id);
        }

        public void Edit(ArticleModel updatedArticle)
        {
            var dto = ModelConverter.ConvertModelToDto(updatedArticle);
            DalFactory.ArticleHandler.Update(dto);
        }

        public Tag GetCategory(int categoryId)
        {
            return DalFactory.CategoryHandler.GetCategoryById(categoryId);
        }

    }
}
