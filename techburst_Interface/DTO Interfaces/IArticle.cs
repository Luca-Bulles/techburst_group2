using System;

namespace techburst_Interface
{
    public interface IArticle
    {
         int ArticleID { get; set; }
         int AccountID { get; set; }
         string Title { get; set; }
         string ArticleText { get; set; }
         DateTime DateCreated { get; set; }
         bool Draft { get; set; }
         DateTime LastEdited { get; set; }
         string Images { get; set; }
    }
}
