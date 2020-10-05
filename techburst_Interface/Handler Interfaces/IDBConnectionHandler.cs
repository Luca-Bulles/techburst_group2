using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace techburst_Interface.Handler_Interfaces
{
    public interface IDBConnectionHandler
    {
        SqlConnection connection { get; }
        SqlConnection Open();
        bool Close();

    }
}
