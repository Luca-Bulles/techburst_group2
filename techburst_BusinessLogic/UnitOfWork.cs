using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using techburst_Data_Access_Layer.Handler;

namespace techburst_BusinessLogic
{
    public class UnitOfWork : IUnitOfWork
    {
        private ArticleHandler _articleHandler;
        private string _conString;

        public UnitOfWork(string conString)
        {
            _conString = conString;
        }
        public ArticleHandler ArticleHandler
        {
            get
            {
                if (_articleHandler == null)
                {
                    _articleHandler = new ArticleHandler(_conString);
                }

                return _articleHandler;
            }
        }
    }
}
