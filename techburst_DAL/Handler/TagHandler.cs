using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Entities.DTO;
using Entities.Enums;
using Interfaces;
using techburst_Interface.Handler_Interfaces;

namespace techburst_DAL.Handler
{
    public class TagHandler : ITagHandler
    {
        private static string connectionString = "";
        private IDBConnectionHandler _dbCon;
        private List<TagDto> _tags;

        public TagHandler(IDBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }

        public List<TagDto> GetAllTags()
        {
            _tags = new List<TagDto>();
            using (SqlConnection connection = _dbCon.Open())
            {
                string query = $"SELECT * FROM Subject;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //connection.Open();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            TagDto tag = new TagDto()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };

                            _tags.Add(tag);

                        }
                    }

                    return _tags;
                }
            }
        }

        public TagDto GetTagById(int id)
        {
            TagDto tag = null;
            using (SqlConnection connection = _dbCon.Open())
            {
                string query = $"SELECT SubjectName FROM Subject WHERE SubjectId = @TagID ;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TagID", id);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        tag = new TagDto()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                    }
                }

                return tag;
            }
        }
    }
}
