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
                string query = "SELECT * FROM [dbi434548_rockstars].[dbo].[Articles]";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    //connection.Open();
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
                           Categories = reader.GetInt32(8)
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
                string query = "INSERT INTO [dbi434548_rockstars].[dbo].[Articles] (AccountID, Title, ArticleText, DateCreated, Draft, LastEdited, Images) VALUES (@AccountID, @Title, @ArticleText, @DateCreated, @Draft, @LastEdited, @Images)";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    
                    command.Parameters.AddWithValue("@AccountID", C1.AccountID);
                    command.Parameters.AddWithValue("@Title", C1.Title);
                    command.Parameters.AddWithValue("@ArticleText", C1.ArticleText);
                    command.Parameters.AddWithValue("@DateCreated", C1.DateCreated);
                    command.Parameters.AddWithValue("@LastEdited", C1.LastEdited);
                    command.Parameters.AddWithValue("@Images", C1.Images);
                    command.Parameters.AddWithValue("@Draft", C1.Draft);
                   

                    command.ExecuteNonQuery();
  
                }
            }

        }


        public void Update(ArticleDto E1)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Articles SET Title = @Title, ArticleText = @ArticleText, DateCreated = @DateCreated, Draft = @Draft, LastEdited = @LastEdited, Images = @Images WHERE = ArticlesID = @ArticlesID ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArticleID", E1.ArticleID);
                    command.Parameters.AddWithValue("@AccountID", E1.AccountID);
                    command.Parameters.AddWithValue("@Title", E1.Title);
                    command.Parameters.AddWithValue("@ArticleText", E1.ArticleText);
                    command.Parameters.AddWithValue("@DateCreated", E1.DateCreated);
                    command.Parameters.AddWithValue("@Draft", E1.Draft);
                    command.Parameters.AddWithValue("@LastEdited", E1.LastEdited);
                    command.Parameters.AddWithValue("@Images", E1.Images);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int ID)
        {
            using (_dbCon.Open())
            {
                string query = "DELETE FROM Articles WHERE ArticleID = @ArticleID";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    command.Parameters.AddWithValue("@ArticleID", ID);
                    command.ExecuteNonQuery();
                }
            }
        }
        public ArticleDto GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Articles WHERE ArticleID = @ArticleID; ";
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
                            Categories = reader.GetInt32(8)
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
