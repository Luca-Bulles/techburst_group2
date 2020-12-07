using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace techburst_group2.Models
{
    public class UservViewModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public string Password { get; set; }
        public string ConPassword { get; set; }
        public string Role { get; set; }
    }
}
