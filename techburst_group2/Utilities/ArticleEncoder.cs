using System.Net;

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
    }
}
