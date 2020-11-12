using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;
using Factories;
using Interfaces.BLL;
using techburst_BLL.Utilities;

namespace techburst_BLL
{
    public class ArticleModel : IArticleModel
    {
        public List<ITagModel> Categories { get; set; }
        public int TagID { get; set; }
        public int Id { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string ArticleText { get; set; }
        public DateTime DateCreated { get; set; }
        public double Draft { get; set; }
        public DateTime LastEdited { get; set; }
        public string Images { get; set; }
       
        public ArticleModel()
        {
            Categories = new List<ITagModel>();
        }

        public void Delete(int id)
        {
            DalFactory.ArticleHandler.Delete(id);
        }

        public void Edit(IArticleModel updatedArticle)
        {
            var dto = ModelConverter.ConvertModelToDto(updatedArticle);
            DalFactory.ArticleHandler.Update(dto);
        }



    }
}
