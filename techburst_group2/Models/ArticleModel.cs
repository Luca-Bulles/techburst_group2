using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace techburst_group2.Models
{
    public class ArticleModel
    {
        public ArticleModel()
        {

        }
        public ArticleModel(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }
    }
}
