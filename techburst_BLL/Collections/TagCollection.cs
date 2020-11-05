using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.DTO;
using Entities.Enums;
using Factories;
using Interfaces.BLL;
using techburst_BLL.Models;
using techburst_BLL.Utilities;

namespace techburst_BLL.Collections
{
    public class TagCollection
    {
        private List<TagDto> _dtos;
        private List<ITagModel> _tags;
        private TagModel _tag;

        public TagCollection()
        {
            _tags = new List<ITagModel>();
        }

        public void Create(ITagModel tag)
        {
            if (tag != null)
            {
                var dto = ModelConverter.ConvertTagModelToDto(tag);
                DalFactory.TagHandler.Create(dto);
            }
        }
        public List<ITagModel> GetAllTags()
        {
            _dtos = DalFactory.TagHandler.GetAllTags();
            foreach (var dto in _dtos)
            {
                _tags.Add(_tag = new TagModel() {Id = dto.Id, Name = dto.Name});
            }
            return _tags;
        }

        public TagModel GetById(int id)
        {
            _tag = null;

            for (int i = 0; i < _tags.Count; i++)
            {
                if (_tags[i].Id == id)
                {
                    _tag = new TagModel() {Id = _tags[i].Id, Name = _tags[i].Name};
                }
            }
            return _tag;
        }
    }
}
