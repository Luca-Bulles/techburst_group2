using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;

namespace techburst_BLL
{
    public class Article
    {
        public Tags Tags { get; set; }
        public Category Categories { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArticleText { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Draft { get; set; }
        public DateTime LastEdited { get; set; }
        public string Images { get; set; }

    }
}
