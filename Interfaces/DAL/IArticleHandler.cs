﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;
using techburst_Data_Access_Layer.DTO;

namespace Interfaces
{
    public interface IArticleHandler : IHandler<ArticleDto>
    {
        List<ArticleDto> GetArticlesByTag(int id);
        ArticleDto GetById(int id);
    }
}
