using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;
using Entities.Enums;
using Factories;

namespace techburst_BLL.Collections
{
    public class TagCollection
    {
        private List<TagDto> _tags;
        public List<TagDto> GetAllTags()
        {
            _tags = DalFactory.CategoryHandler.GetAllTags();
            return _tags;
        }
    }
}
