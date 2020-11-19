using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Entities.Enums;
using techburst_BLL.Collections;
using techburst_BLL.Models;

namespace techburst_group2.Models
{
    public class TagViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
