using Factories;
using Interfaces.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using techburst_BLL.Models;
using techburst_BLL.Utilities;

namespace techburst_BLL.Collections
{
    public class ContactCollection 
    {
        public void Create(ContactModel item)
        {
            var result = ModelConverter.ConvertContactmodelToDTO(item);
            DalFactory.contactHandler.Create(result);
        }
    }
}
