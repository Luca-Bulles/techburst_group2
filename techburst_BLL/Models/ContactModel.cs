using Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace techburst_BLL.Models
{
    public class ContactModel : IContactModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Question { get; set; }
    }
}
