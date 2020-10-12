using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Entities.Enums;
using Interfaces;
using techburst_Interface.Handler_Interfaces;

namespace techburst_DAL.Handler
{
    public class CategoryHandler : ICategoryHandler
    {
        private static string connectionString = "";
        private IDBConnectionHandler _dbCon;

        public CategoryHandler(IDBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }
        public Tag GetCategoryById(int id)
        {
            string unParsedCategory = "";
            Tag parsedCategory;
            using (SqlConnection connection = _dbCon.Open())
            {
                string query = $"SELECT SubjectName FROM Subject WHERE SubjectId = {id};";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArticleID", id);
                    //connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        unParsedCategory = reader.GetString(0);
                    }

                    connection.Close();
                    parsedCategory = Enum.Parse<Tag>(unParsedCategory);
                }

                return parsedCategory;
            }
        }
    }
}
