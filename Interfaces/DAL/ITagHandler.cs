using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;
using Entities.Enums;

namespace Interfaces
{
    public interface ITagHandler
    {
        void Create(TagDto tag);
        void Update(TagDto tag);
        void Delete(int id);
        List<TagDto> GetAllTags();
    }
}
