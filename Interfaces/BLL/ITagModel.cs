using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.BLL
{
    public interface ITagModel
    {
        int Id { get; set; }
        string Name { get; set; }
        void Edit(ITagModel tag);
    }
}
