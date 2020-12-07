using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace techburst_group2.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the techburst_group2User class
    public class techburst_group2User : IdentityUser
    {
        [PersonalData]
        [Column(TypeName ="Nvarchar(50)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "Nvarchar(50)")]
        public string LastName { get; set; }
    }
}
