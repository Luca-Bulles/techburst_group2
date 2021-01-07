using Entities.DTO;
using Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using techburst_Interface.Handler_Interfaces;

namespace techburst_DAL.Handler
{
    public class ContactHandler :IContactHandler
    {
        private static string connectionString = "";
        private IDBConnectionHandler _dbCon;

        public ContactHandler(IDBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }
        public void Create(ContactDTO C1)
        {
            using (_dbCon.Open())
            {
                string query = "Insert into [dbo].[Question] (Firstname, Lastname, Email, Question) VALUES (@Firstname, @Lastname, @Email, @Question);";

                using SqlCommand command = new SqlCommand(query, _dbCon.connection);
                command.Parameters.AddWithValue("@Firstname", C1.Firstname);
                command.Parameters.AddWithValue("@Lastname", C1.Lastname);
                command.Parameters.AddWithValue("@Email", C1.Email);
                command.Parameters.AddWithValue("@Question", C1.Question);

                command.ExecuteNonQuery();
            }

        }
    }
}
