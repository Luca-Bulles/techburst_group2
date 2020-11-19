using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Entities.DTO;
using Entities.Enums;
using Interfaces;
using techburst_Interface.Handler_Interfaces;

namespace techburst_DAL.Handler
{
    public class TagHandler : ITagHandler
    {
        private IDBConnectionHandler _dbCon;
        private List<TagDto> _tags;

        public TagHandler(IDBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }

        public void Create(TagDto tag)
        {
            using (_dbCon.Open())
            {
                string query = "INSERT INTO [dbi434548_rockstars].[dbo].[Tags] (TagName) VALUES (@TagName)";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@TagName", tag.Name);

                    command.ExecuteNonQuery();

                }
            }
        }

        public void Update(TagDto tag)
        {
            using (_dbCon.Open())
            {
                string query = "UPDATE Tags SET TagName = @TagName WHERE TagID = @TagID";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@TagName", tag.Name);
                    command.Parameters.AddWithValue("TagID", tag.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TagDto> GetAllTags()
        {
            _tags = new List<TagDto>();
            using (_dbCon.Open())
            {
                string query = $"SELECT * FROM [dbi434548_rockstars].[dbo].[Tags]";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TagDto tag = new TagDto()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            };

                            _tags.Add(tag);
                    }

                    return _tags;
                }
            }
        }
    }
}
