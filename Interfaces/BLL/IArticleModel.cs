using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.BLL
{
    public interface IArticleModel
    {
        List<ITagModel> Categories { get; set; }
        int TagID { get; set; }
        string TagName { get; set; }
        int Id { get; set; }
        string Author { get; set; }
        int AuthorId { get; set; }
        string Title { get; set; }
        string ArticleText { get; set; }
        DateTime DateCreated { get; set; }
        double Draft { get; set; }
        DateTime LastEdited { get; set; }
        string Images { get; set; }


        void Delete(int id);

        void Edit(IArticleModel article);
    }
}
