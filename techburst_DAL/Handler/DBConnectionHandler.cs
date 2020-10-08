using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using techburst_Interface.Handler_Interfaces;

namespace techburst_Data_Access_Layer.Handler
{
    public class DBConnectionHandler : IDBConnectionHandler
    {
        private protected string connectionString = "Server=mssql.fhict.local;Database=dbi434548_rockstars";
        public SqlConnection connection { get; private set; }
        public SqlConnection Open()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
