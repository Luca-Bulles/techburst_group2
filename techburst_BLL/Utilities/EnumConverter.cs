using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;

namespace techburst_BLL.Utilities
{
    public static class EnumConverter
    {
        public static Tag ConvertToTagEnum(string input)
        {
            return Enum.Parse<Tag>(input);
        }

    }
}
