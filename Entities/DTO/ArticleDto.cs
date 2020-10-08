using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;

namespace techburst_Data_Access_Layer.DTO
{
    public class ArticleDto
    {
       public int ArticleID { get; set; }
        public int AccountID { get; set; }
        public string Title { get; set; }
        public string ArticleText { get; set; }
        public string Categories { get; set; }
        public string Tags { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Draft { get; set; }
        public DateTime LastEdited { get; set; }
        public string Images { get; set; }
    }
}
