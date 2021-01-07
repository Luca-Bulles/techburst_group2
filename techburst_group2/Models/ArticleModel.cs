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

        private DateTime? date;

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt
        {
            get { return date ?? DateTime.Today; }
            set { date = value; }
        }
        private DateTime? enddate;

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime LastEdited
        {
            get { return enddate ?? DateTime.Today.Date; }
            set { enddate = value; }
        }
        
        [Required]
        public bool Draft { get; set; }
    }
}
