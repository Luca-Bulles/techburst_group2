using System;
using System.Collections.Generic;
using System.Text;
using techburst_Interface;

namespace techburst_Data_Access_Layer.DTO
{
    public class Article: IArticle
    {
       public int ArticleID { get; set; }
        public int AccountID { get; set; }
        public string Title { get; set; }
        public string ArticleText { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Draft { get; set; }
        public DateTime LastEdited { get; set; }
        public string Images { get; set; }
    }
}
