using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;
using Entities.Enums;

namespace Interfaces
{
    public interface ITagHandler
    {
        List<TagDto> GetAllTags();
        TagDto GetTagById(int id);
    }
}
