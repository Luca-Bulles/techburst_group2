using System;
using Interfaces;
using techburst_DAL.Handler;
using techburst_Data_Access_Layer.Handler;

namespace Factories
{
    public static class DalFactory
    {
        private static IArticleHandler _articleHandler;
        private static ICategoryHandler _categoryHandler;
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

        public static ICategoryHandler CategoryHandler
        {
            get
            {
                if (_categoryHandler == null)
                {
                    _categoryHandler = new CategoryHandler(new DBConnectionHandler());
                }

                return _categoryHandler;
            }
        }
    }
}
