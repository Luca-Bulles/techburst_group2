using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace techburst_BLL.Utilities
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
