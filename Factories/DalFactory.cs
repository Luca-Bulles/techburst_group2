﻿using System;
using Interfaces;
using Interfaces.DAL;
using techburst_DAL.Handler;
using techburst_Data_Access_Layer.Handler;

namespace Factories
{
    public static class DalFactory
    {
        private static IArticleHandler _articleHandler;
        private static ITagHandler _tagHandler;
        private static IUserHandler _userHandler;
        private static IRoleHandler _roleHandler;
        private static IContactHandler _contacthandler;

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

        public static IUserHandler UserHandler
        {
            get
            {
                if (_userHandler == null)
                {
                    _userHandler = new UserHandler(new DBConnectionHandler());
                }

                return _userHandler;
            }
        }

        public static ITagHandler TagHandler
        {
            get
            {
                if (_tagHandler == null)
                {
                    _tagHandler = new TagHandler(new DBConnectionHandler());
                }

                return _tagHandler;
            }
        }

        public static IRoleHandler RoleHandler
        {
            get
            {
                if (_roleHandler == null)
                {
                    _roleHandler = new RoleHandler(new DBConnectionHandler());
                }

                return _roleHandler;
            }
        }
        public static IContactHandler contactHandler
        {
            get
            {
                if (_contacthandler == null)
                {
                    _contacthandler = new ContactHandler(new DBConnectionHandler());
                }
                return _contacthandler;
            }
        }
    }
}
