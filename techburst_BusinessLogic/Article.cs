using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techburst_Interface;

namespace techburst_BusinessLogic
{
    public class Article
    {
        private IUnitOfWork unitOfWork;
        public int ArticleID { get; private set; }
        public int AccountID { get; private set; }
        public string Title { get; private set; }
        public string ArticleText { get; private set; }
        public DateTime DateCreated { get; private set; }
        public bool Draft { get; private set; }
        public DateTime LastEdited { get; private set; }
        public string Image { get; private set; }
        public string ApprovedBy { get; private set; }
        public List<string> Images { get; private set; }

        public Article(int articleId, int accountId, string title, string articleText, bool draft)
        {
            ArticleID = articleId;
            AccountID = accountId;
            Title = title;
            ArticleText = articleText;
            DateCreated = DateTime.Now;
            LastEdited = DateTime.Now;
            Draft = draft;
            Images = new List<string>();

        }

        public void AddImage(string imageUrl)
        {
            Image = imageUrl;
            Images.Add(Image);
        }

        public void RemoveImage(string url)
        {
            Images.Remove(url);
        }

        public string EditText(string text)
        {
            ArticleText = text;
            LastEdited = DateTime.Now;

            return text;
        }

        public string FindTags(int articleId)
        {
            //unitOfWork = new UnitOfWork();
            return "Implement this method.";
        }
    }
}
