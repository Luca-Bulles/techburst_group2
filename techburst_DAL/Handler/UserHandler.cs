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
                            UserId = reader.GetInt32(0),
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
                string query = "INSERT INTO [dbi434548_rockstars].[dbo].[User] (FirstName, LastName, Email, Password, Role) VALUES (@FirstName, @LastName, @Email, @Password, @Role)";
                using (SqlCommand create = new SqlCommand(query, _dbCon.connection))
                {
                    create.Parameters.AddWithValue("@FirstName", user.FirstName);
                    create.Parameters.AddWithValue("@LastName", user.LastName);
                    create.Parameters.AddWithValue("@Email", user.Email);
                    create.Parameters.AddWithValue("@Password", user.Password);
                    create.Parameters.AddWithValue("@Role", user.Role);

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
                    "UPDATE [dbi434548_rockstars].[dbo].[User] SET FirstName = @FirstName, LastName = @Lastname, Email = @Email, Password = @Password WHERE UserId = @UserId";
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
                string query = "DELETE FROM [dbi434548_rockstars].[dbo].[User] WHERE UserId = @UserId";
                using (SqlCommand delete = new SqlCommand(query, _dbCon.connection))
                {
                    delete.Parameters.AddWithValue("@UserId", id);
                    delete.ExecuteNonQuery();
                }
                _dbCon.Close();
            }
        }

        public bool Login(UserDto dto)
        {
            using (_dbCon.Open())
            {
                string query = "SELECT COUNT(Email) FROM [dbi434548_rockstars].[dbo].[User] WHERE Email = @Email AND Password = @Password";
                using (SqlCommand login = new SqlCommand(query, _dbCon.connection))
                {
                    login.Parameters.AddWithValue("@Email", dto.Email);
                    login.Parameters.AddWithValue("@Password", dto.Password);
                    var result = (int) login.ExecuteScalar();
                    _dbCon.Close();
                    return result != 0;
                }
            }
        }

        public UserDto GetUserFromEmail(string email)
        {
            UserDto dto = new UserDto();
            using (_dbCon.Open())
            {
                string query = "SELECT * FROM [dbi434548_rockstars].[dbo].[User] WHERE Email = @Email";
                using (SqlCommand getUser = new SqlCommand(query, _dbCon.connection))
                {
                    getUser.Parameters.AddWithValue("@Email", email);
                    var reader = getUser.ExecuteReader();
                    while (reader.Read())
                    {
                        dto.UserId = reader.GetInt32(0);
                        dto.FirstName = reader.GetString(1);
                        dto.LastName = reader.GetString(2);
                        dto.Email = reader.GetString(3);
                        dto.Password = reader.GetString(4);
                        dto.Role = reader.GetString(5);
                    }
                    _dbCon.Close();
                }

                return dto;
            }
        }

        public bool CheckIfEmailExists(string email)
        {
            using (_dbCon.Open())
            {
                string query = "SELECT COUNT (Email) FROM [dbi434548_rockstars].[dbo].[User] WHERE Email = @Email";
                using (SqlCommand checkEmail = new SqlCommand(query, _dbCon.connection))
                {
                    checkEmail.Parameters.AddWithValue("@Email", email);
                    var result = (int) checkEmail.ExecuteScalar();
                    _dbCon.Close();
                    return result != 0;
                }
            }
        }
    }
}
