using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using techburst_Data_Access_Layer.Handler;

namespace techburst_BusinessLogic
{
    public interface IUnitOfWork
    {
        ArticleHandler ArticleHandler { get; }
    }
}
