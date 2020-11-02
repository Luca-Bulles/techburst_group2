using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Entities.Enums;

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
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public List<Tag> Tags { get; set; }
        [Required]
        public string Images { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime LastEdited { get; set; }
        [Required]
        public double Draft { get; set; }
    }
}
