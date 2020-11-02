using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;
using Entities.Enums;

namespace techburst_BLL.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Tag TagDbEntity { get; set; }

        public Tag ConvertModelToEntity(TagModel model)
        {
            if (model.Name == "C#")
                model.Name = "CSharp";

            return Enum.Parse<Tag>(model.Name);
        }

        public TagModel ConvertEntityToModel(TagDto dto)
        {

        }
    }
}
