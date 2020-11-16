using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.BLL
{
    public interface IArticleCollection
    {
        void Create(IArticleModel model);
        List<IArticleModel> GetAllArticles();
        List<IArticleModel> GetArticlesByTag(int tagId);
        IArticleModel GetArticleById(int id);
    }
}
