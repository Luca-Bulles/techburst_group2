using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;
using techburst_Data_Access_Layer.DTO;

namespace Interfaces
{
    public interface IArticleHandler : IHandler<ArticleDto>
    {
        ArticleDto GetById(int id);
    }
}
