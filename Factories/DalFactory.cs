using System;
using Interfaces;
using techburst_DAL.Handler;
using techburst_Data_Access_Layer.Handler;

namespace Factories
{
    public static class DalFactory
    {
        private static IArticleHandler _articleHandler;
        public static IArticleHandler ArticleHandler
        {
            get
            {
                if (_articleHandler == null)
                {
                    _articleHandler = new ArticleHandler(new DBConnectionHandler());
                }
                return _articleHandler;
            }

        }
    }
}
