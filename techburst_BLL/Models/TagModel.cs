using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;
using Entities.Enums;
using Factories;
using Interfaces.BLL;
using techburst_BLL.Utilities;

namespace techburst_BLL.Models
{
    public class TagModel : ITagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Edit(ITagModel tag)
        {
            if (tag != null)
            {
                TagDto dto = ModelConverter.ConvertTagModelToDto(tag);
                DalFactory.TagHandler.Update(dto);
            }
        }

        public void Delete(int id)
        {
            DalFactory.TagHandler.Delete(id);
        }
    }
}
