using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;
using Entities.Enums;
using Interfaces.BLL;

namespace techburst_BLL.Models
{
    public class TagModel : ITagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        

    }
}
