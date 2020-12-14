using System.Net;
using System.Text.RegularExpressions;

namespace techburst_group2.Utilities
{
    public class ArticleTextManager
    {
        public static string EncodeArticleText(string articleText)
        {
            return WebUtility.HtmlEncode(articleText);
        }

        public static string DecodeArticleText(string articleText)
        {
            return WebUtility.HtmlDecode(articleText).ToString();
        }

        public static string ParseHtmlTags(string articleText)
        {
            return Regex.Replace(articleText, @"<(.|\n)*?>", string.Empty);
        }

        public static string ParseHeaderContent(string articleText)
        {
            return Regex.Replace(articleText, @"\s?<h[0-9]>[^<]+</h[0-9]>\s?", string.Empty);
        }
    }
}
