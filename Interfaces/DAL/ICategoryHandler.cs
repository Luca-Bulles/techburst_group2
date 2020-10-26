using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;
using Entities.Enums;

namespace Interfaces
{
    public interface ICategoryHandler
    {
        List<TagDto> GetAllTags();
        Tag GetCategoryById(int id);
    }
}
