using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.BLL
{
    public interface ITagCollection
    {
        void Create(ITagModel tag);
        List<ITagModel> GetAllTags();
        ITagModel GetById(int id);
    }
}
