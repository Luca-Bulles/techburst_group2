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
    public class TagCollection : ITagCollection
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
            List<ITagModel> tagList = new List<ITagModel>();
            _dtos = DalFactory.TagHandler.GetAllTags();
            foreach (var dto in _dtos)
            {
                tagList.Add(_tag = new TagModel() {Id = dto.Id, Name = dto.Name});
            }
            return tagList;
        }

        public ITagModel GetById(int id)
        {
            _tag = null;
            _tags = GetAllTags();

            for (int i = 0; i < _tags.Count; i++)
            {
                if (_tags[i].Id == id)
                {
                    _tag = new TagModel() {Id = _tags[i].Id, Name = _tags[i].Name};
                }
            }
            return _tag;
        }

        public ITagModel GetByName(string name)
        {
            if (!String.IsNullOrEmpty(name))
            {
                _tags = GetAllTags();
                for (int i = 0; i < _tags.Count; i++)
                {
                    if (_tags[i].Name == name)
                    {
                        _tag = new TagModel() { Id = _tags[i].Id, Name = _tags[i].Name};
                    }
                }
            }

            return _tag;
        }
    }
}
