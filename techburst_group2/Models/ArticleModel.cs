using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Entities.Enums;
using Newtonsoft.Json;
using techburst_group2.Models;

namespace techburst_group2.Models
{
    public class ArticleModel
    {
        public ArticleModel()
        {
        }
        public ArticleModel(string title, string content, string author, string image)
        {
            Title = title;
            Content = content;
            Author = author;
            Images = image;

        }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required] 
        public string Content { get; set; } = "";
        
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public int TagID { get; set; }
        [Required]
        public string TagName { get; set; }
        public string Images { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }
        [Required]
        public bool Draft { get; set; }
    }
}
