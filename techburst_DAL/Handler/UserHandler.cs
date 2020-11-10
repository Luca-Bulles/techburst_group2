using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Entities.DTO;
using Interfaces.DAL;
using techburst_Interface.Handler_Interfaces;

namespace techburst_DAL.Handler
{
    public class UserHandler : IUserHandler
    {

        private static string connectionString = "";
        private IDBConnectionHandler _dbCon;

        public UserHandler(IDBConnectionHandler dbCon)
        {
            _dbCon = dbCon;
        }

        public List<UserDto> GetAll()
        {
            var users = new List<UserDto>();
            using (_dbCon.Open())
            {
                string query = "SELECT * FROM [dbi434548_rockstars].[dbo].[Users]";
                using (SqlCommand getAll = new SqlCommand(query, _dbCon.connection))
                {
                    var reader = getAll.ExecuteReader();
                    while (reader.Read())
                    {
                        UserDto dto = new UserDto()
                        {
                            UserId = reader.GetString(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            Password = reader.GetString(4)
                        };
                        users.Add(dto);
                    }
                    _dbCon.Close();
                }
            }

            return users;
        }

        public void Create(UserDto user)
        {
            using (_dbCon.Open())
            {
                string query = "INSERT INTO [dbi434548_rockstars].[dbo].[User] (FirstName, LastName, Email, Password) VALUES (@FirstName, @LastName, @Email, @Password)";
                using (SqlCommand create = new SqlCommand(query, _dbCon.connection))
                {
                    create.Parameters.AddWithValue("@FirstName", user.FirstName);
                    create.Parameters.AddWithValue("@LastName", user.LastName);
                    create.Parameters.AddWithValue("@Email", user.Email);
                    create.Parameters.AddWithValue("@Password", user.Password);

                    create.ExecuteNonQuery();
                }
                _dbCon.Close();
            }
        }

        public void Update(UserDto user)
        {
            using (_dbCon.Open())
            {
                string query =
                    "UPDATE User SET FirstName = @FirstName, LastName = @Lastname, Email = @Email, Password = @Password WHERE UserId = @UserId";
                using (SqlCommand update = new SqlCommand(query, _dbCon.connection))
                {
                    update.Parameters.AddWithValue("@UserId", user.UserId);
                    update.Parameters.AddWithValue("@FirstName", user.FirstName);
                    update.Parameters.AddWithValue("@LastName", user.LastName);
                    update.Parameters.AddWithValue("@Email", user.Email);
                    update.Parameters.AddWithValue("@Password", user.Password);

                    update.ExecuteNonQuery();
                }
                _dbCon.Close();
            }
        }

        public void Delete(int id)
        {
            using (_dbCon.Open())
            {
                string query = "DELETE FROM User WHERE UserId = @UserId";
                using (SqlCommand delete = new SqlCommand(query, _dbCon.connection))
                {
                    delete.Parameters.AddWithValue("@UserId", id);
                    delete.ExecuteNonQuery();
                }
                _dbCon.Close();
            }
        }
    }
}
