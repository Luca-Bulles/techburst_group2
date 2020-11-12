using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Entities.DTO;
using Interfaces;
using Interfaces.DAL;
using techburst_Interface.Handler_Interfaces;

namespace techburst_DAL.Handler
{
    public class RoleHandler : IRoleHandler
    {
        private readonly IDBConnectionHandler _dbCon;
        private static string connectionString = "";

        public RoleHandler(IDBConnectionHandler _dbCon)
        {
            this._dbCon = _dbCon;
        }

        public List<RoleDto> GetAll()
        {
            List<RoleDto> dtos = new List<RoleDto>();
            using (_dbCon.Open())
            {
                string query = "SELECT * FROM Role";
                using (SqlCommand getAll = new SqlCommand(query, _dbCon.connection))
                {
                    var reader = getAll.ExecuteReader();
                    while (reader.Read())
                    {
                        RoleDto dto = new RoleDto()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                        dtos.Add(dto);
                    }
                    _dbCon.Close();
                    return dtos;
                }
            }
        }

        public void Create(RoleDto entity)
        {
            using (_dbCon.Open())
            {
                string query = "INSERT INTO Role(RoleId, RoleName) VALUES (@RoleId, @RoleName)";
                using (SqlCommand create = new SqlCommand(query, _dbCon.connection))
                {
                    create.Parameters.AddWithValue("@RoleId", entity.Id);
                    create.Parameters.AddWithValue("@RoleName", entity.Name);
                    create.ExecuteNonQuery();
                    _dbCon.Close();
                }
            }
        }

        public void Update(RoleDto entity)
        {
            using (_dbCon.Open())
            {
                string query = "UPDATE Role SET RoleName = @RoleName WHERE RoleId = @RoleId";
                using (SqlCommand update = new SqlCommand(query, _dbCon.connection))
                {
                    update.Parameters.AddWithValue("@RoleName", entity.Name);
                    update.Parameters.AddWithValue("@RoleId", entity.Id);
                    update.ExecuteNonQuery();
                    _dbCon.Close();
                }
            }
        }

        public void Delete(int id)
        {
            using (_dbCon.Open())
            {
                string query = "DELETE FROM Role WHERE RoleId = @RoleId";
                using (SqlCommand delete = new SqlCommand(query, _dbCon.connection))
                {
                    delete.Parameters.AddWithValue("@RoleId", id);
                    delete.ExecuteNonQuery();
                    _dbCon.Close();
                }
            }
        }

        public void AddUserToRole(RoleDto role, UserDto user)
        {
            using (_dbCon.Open())
            {
                string query = "UPDATE User SET RoleId = @RoleId WHERE UserId = @UserId";
                using (SqlCommand add = new SqlCommand(query, _dbCon.connection))
                {
                    add.Parameters.AddWithValue("@RoleId", role.Id);
                    add.Parameters.AddWithValue("@UserId", user.UserId);
                    add.ExecuteNonQuery();
                    _dbCon.Close();
                }
            }
        }

        public void RemoveUserFromRole(RoleDto role, UserDto user)
        {
            using (_dbCon.Open())
            {
                string query = "UPDATE User SET RoleId = NULL WHERE UserId = @UserId";
                using (SqlCommand remove = new SqlCommand(query, _dbCon.connection))
                {
                    remove.Parameters.AddWithValue("@UserId", user.UserId);
                    remove.ExecuteNonQuery();
                    _dbCon.Close();
                }
            }
        }

        public RoleDto GetRoleFromId(int id)
        {
            RoleDto dto = new RoleDto();
            using (_dbCon.Open())
            {
                string query = "SELECT * From Role WHERE RoleId = @RoleId";
                using (SqlCommand get = new SqlCommand(query, _dbCon.Open()))
                {
                    get.Parameters.AddWithValue("RoleId", id);
                    var reader = get.ExecuteReader();
                    while (reader.Read())
                    {
                        dto.Id = reader.GetInt32(0);
                        dto.Name = reader.GetString(1);
                    }
                    _dbCon.Close();
                    return dto;
                }
            }
        }

        public int GetRoleFromUser(int id)
        {
            using (_dbCon.Open())
            {
                string query = "SELECT RoleId FROM User WHERE UserId = @UserId";
                using (SqlCommand get = new SqlCommand(query, _dbCon.connection))
                {
                    get.Parameters.AddWithValue("@UserId", id);
                    var result = (int) get.ExecuteScalar();
                    _dbCon.Close();
                    return result;
                }
            }
        }
    }
}
