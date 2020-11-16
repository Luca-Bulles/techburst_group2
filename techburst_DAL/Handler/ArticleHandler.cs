using System.Collections.Generic;
using System.Data.SqlClient;
using Entities.Enums;
using Interfaces;
using techburst_Data_Access_Layer.DTO;
using techburst_Interface.Handler_Interfaces;

namespace techburst_DAL.Handler
{
    public class ArticleHandler : IArticleHandler
    {
        private static string connectionString = "";
        private IDBConnectionHandler _dbCon;

        public ArticleHandler(IDBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }
        public List<ArticleDto> GetAll()
        {
            var articles = new List<ArticleDto>();
            using (_dbCon.Open())
            {
                string query =
                    "SELECT Articles.ArticleID, Articles.AccountID, Articles.Title, Articles.ArticleText, Articles.DateCreated, Articles.Draft, Articles.LastEdited, Articles.Images, a1.TagID, t.TagName " +
                    "FROM Articles " +
                    "INNER JOIN ArticleTag a1 on Articles.ArticleID = a1.ArticleID " +
                    "INNER JOIN Tags t on a1.TagID = t.TagID;";

                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ArticleDto ArticleDTO = new ArticleDto
                        {
                           ArticleID = reader.GetInt32(0),
                           AccountID = reader.GetInt32(1),
                           Title = reader.GetString(2),
                           ArticleText = reader.GetString(3),
                           DateCreated = reader.GetDateTime(4),
                           Draft = reader.GetDouble(5),
                           LastEdited = reader.GetDateTime(6),
                           Images = reader.GetString(7),
                           TagID = reader.GetInt32(8),
                           TagName = reader.GetString(9)
                        };

                        articles.Add(ArticleDTO);
                    }

                    _dbCon.Close();
                }
            }
            return articles;
        }

        public void Create(ArticleDto C1)
        {
            using (_dbCon.Open()) 
            {
                string query = "BEGIN TRANSACTION [T1]; " +
                               "INSERT INTO [dbi434548_rockstars].[dbo].[Articles] (AccountID, Title, ArticleText, DateCreated, Draft, LastEdited, Images) " +
                               "VALUES (@AccountID, @Title, @ArticleText, CURRENT_TIMESTAMP, @Draft, CURRENT_TIMESTAMP, @Images); " +
                               "INSERT INTO [dbi434548_rockstars].[dbo].[ArticleTag] (TagID, ArticleID) " +
                               "VALUES (@TagID, IDENT_CURRENT('Articles')); " +
                               "COMMIT TRANSACTION [T1];";

                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@AccountID", C1.AccountID);
                    command.Parameters.AddWithValue("@Title", C1.Title);
                    command.Parameters.AddWithValue("@ArticleText", C1.ArticleText);
                    command.Parameters.AddWithValue("@Draft", C1.Draft);
                    command.Parameters.AddWithValue("@Images", C1.Images);
                    command.Parameters.AddWithValue("@TagID", C1.TagID);

                    command.ExecuteNonQuery();
                }
            }

        }

        public void Update(ArticleDto E1)
        {
            using (_dbCon.Open())
            {
                string query = "UPDATE Articles SET Title = @Title, ArticleText = @ArticleText, Draft = @Draft, LastEdited = CURRENT_TIMESTAMP, Images = @Images WHERE ArticleID = @ArticleID";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@ArticleID", E1.ArticleID);
                    command.Parameters.AddWithValue("@AccountID", E1.AccountID);
                    command.Parameters.AddWithValue("@Title", E1.Title);
                    command.Parameters.AddWithValue("@ArticleText", E1.ArticleText);
                    command.Parameters.AddWithValue("@Draft", E1.Draft);
                    command.Parameters.AddWithValue("@Images", E1.Images);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int ID)
        {
            using (_dbCon.Open())
            {
                string query = "BEGIN TRANSACTION [T2]; " +
                               "DELETE FROM ArticleTag WHERE ArticleID = @ArticleTagID;" +
                               "DELETE FROM Articles WHERE ArticleID = @ArticleID;" +
                               "COMMIT TRANSACTION [T2]";

                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@ArticleTagID", ID);
                    command.Parameters.AddWithValue("@ArticleID", ID);
                    command.ExecuteNonQuery();
                }
            }
        }
        public ArticleDto GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Articles WHERE ArticleID = @ArticleID;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArticleID", id);
                }
            }
            return new ArticleDto();
        }

        public List<ArticleDto> GetArticlesByTag(int tagId)
        {
            List<ArticleDto> articles = new List<ArticleDto>(
                );
            using (_dbCon.Open())
            {
                string query = "SELECT * FROM Article WHERE SubjectName = @TagId; ";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("TagId", tagId);

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ArticleDto ArticleDTO = new ArticleDto
                        {
                            ArticleID = reader.GetInt32(0),
                            AccountID = reader.GetInt32(1),
                            Title = reader.GetString(2),
                            ArticleText = reader.GetString(3),
                            DateCreated = reader.GetDateTime(4),
                            Draft = reader.GetDouble(5),
                            LastEdited = reader.GetDateTime(6),
                            Images = reader.GetString(7),
                            TagID = reader.GetInt32(8)
                        };

                        articles.Add(ArticleDTO);
                    }

                    _dbCon.Close();
                }

                return articles;
            }
        }
    }
}
