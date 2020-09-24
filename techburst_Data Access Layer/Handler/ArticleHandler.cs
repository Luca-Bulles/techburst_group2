using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using techburst_Data_Access_Layer.DTO;
using techburst_Interface;
using techburst_Interface.Handler_Interfaces;

namespace techburst_Data_Access_Layer.Handler
{
    public class ArticleHandler
    {
        private static string connectionString = "";
        private IDBConnectionHandler _dbCon;

        public ArticleHandler(IDBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }
        public List<IArticle> GetArticles()
        {
            var articles = new List<IArticle>();
            using (_dbCon.Open())
            {
                string query = "SELECT * FROM [dbi434548].[dbo].[Car]";
                using (SqlCommand command = new SqlCommand(query, _dbCon.connection))
                {
                    //connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Article ArticleDTO = new Article
                        {
                           ArticleID = reader.GetInt32(0),
                           AccountID = reader.GetInt32(1),
                           Title = reader.GetString(2),
                           ArticleText = reader.GetString(3),
                           DateCreated = reader.GetDateTime(4),
                           Draft = reader.GetBoolean(5),
                           LastEdited = reader.GetDateTime(6),
                           Images = reader.GetString(7)

                        };

                        articles.Add(ArticleDTO);
                    }

                    _dbCon.Close();
                }
            }
            return articles;
        }

        public void CreateArticle(IArticle C1)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [dbi434548_rockstars].[dbo].[Articles] VALUES (@ArticleID, @AccountID, @Title, @ArticleText, @DateCreated, @Draft, @LastEdited, @Images";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArticleID", C1.ArticleID);
                    command.Parameters.AddWithValue("@AccountID", C1.AccountID);
                    command.Parameters.AddWithValue("@Title", C1.Title);
                    command.Parameters.AddWithValue("@ArticleText", C1.ArticleText);
                    command.Parameters.AddWithValue("@DateCreated", C1.DateCreated);
                    command.Parameters.AddWithValue("@Draft", C1.Draft);
                    command.Parameters.AddWithValue("@LastEdited", C1.LastEdited);
                    command.Parameters.AddWithValue("@Images", C1.Images);
                   
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }

        public void UpdateArticle(IArticle E1)
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

        public void DeleteArticle(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Article WHERE ArticleID = @ArticleID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArticleID", ID);
                    command.ExecuteNonQuery();
                }
            }
        }
        public IArticle GetById(IArticle article)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Article WHERE ArticleID = @ArticleID; ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArticleID", article.ArticleID);

                }
            }
            return article;
        }

    }
}
