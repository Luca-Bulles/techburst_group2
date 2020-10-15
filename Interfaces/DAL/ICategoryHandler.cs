using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;

namespace Interfaces
{
    public interface ICategoryHandler
    {
        Tag GetCategoryById(int id);
    }
}
