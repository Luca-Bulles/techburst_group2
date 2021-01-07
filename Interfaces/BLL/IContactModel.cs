using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.BLL
{
    public interface IContactModel
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        string Question { get; set; }
        string Email { get; set; }
    }
}
