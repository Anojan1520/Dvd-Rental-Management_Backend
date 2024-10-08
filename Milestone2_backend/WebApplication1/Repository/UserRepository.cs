using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data.SqlClient;
using WebApplication1.IRepositroy;
using WebApplication1.Modals;

namespace WebApplication1.Repository
{
    public class UserRepository : IUserRepository
    {
        private string connectionString;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<string> Register(Users user)
        {
            var CheckUserName =await GetByUserName(user.username);
            if (CheckUserName == null)
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    var command = connection.CreateCommand();
                    command.CommandText = @"INSERT INTO Users(id,position,firstname,username,password,nic,phone,email)
                                        VALUES(@id,@position,@firstname,@username,@password,@nic,@phone,@email)";
                    command.Parameters.AddWithValue("@id", Guid.NewGuid());
                    command.Parameters.AddWithValue("@position", user.position);
                    command.Parameters.AddWithValue("@firstname", user.firstname);
                    command.Parameters.AddWithValue("@username", user.username);
                    command.Parameters.AddWithValue("@password", user.password);
                    command.Parameters.AddWithValue("@nic", user.nic);
                    command.Parameters.AddWithValue("@phone", user.phone);
                    command.Parameters.AddWithValue("@email", user.email);

                  await command.ExecuteNonQueryAsync();
                }
                return ("Registration Successfull..");

            }
            else
            {
                return ("Your Username Invalid...");
            }



        }

        public async Task<Users> GetByUserName(string UserName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = @"Select * from Users
                                      where Users.username=  @UserName";
                command.Parameters.AddWithValue("@UserName", UserName);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var users = new Users
                        {
                            id = reader.GetGuid(reader.GetOrdinal("id")),
                            firstname = reader.GetString(reader.GetOrdinal("firstname")),
                            username = reader.GetString(reader.GetOrdinal("username")),
                            password = reader.GetString(reader.GetOrdinal("password")),
                            nic = reader.GetString(reader.GetOrdinal("nic")),
                            phone = reader.GetInt32(reader.GetOrdinal("phone")),
                            email = reader.GetString(reader.GetOrdinal("email")),
                        };
                        return users;
                    }
                    return null;

                }
            }
        }


        public async Task<List<Users>> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = @"SELECT id , firstname , username , position , password,nic,phone,email FROM Users";
                var users = new List<Users>();
                using (var Reader = await command.ExecuteReaderAsync())
                {
                    while (Reader.Read())
                    {
                        var obj = new Users
                        {
                            id = Reader.GetGuid(0),
                            firstname = Reader.GetString(1),
                            username = Reader.GetString(2),
                            position = Reader.GetString(3),
                            password = Reader.GetString(4),
                            nic = Reader.GetString(5),
                            phone = Reader.GetInt32(6),
                            email = Reader.GetString(7),
                        };
                        users.Add(obj);

                    }
                }

                return users;
            }
        }

        public async Task<string> UpdateUser(Users user)
        {
            using (var Connection = new SqlConnection(connectionString))
            {
                await Connection.OpenAsync();

                var command = Connection.CreateCommand();
                command.CommandText = @"
                        UPDATE Users
                        SET firstname=@firstname , 
                           username=@username ,
                           position=@position, 
                           password=@password,
                           nic=@nic,
                           phone=@phone,
                           email=@email
                        WHERE id=@id
            ";
                command.Parameters.AddWithValue("@firstname", user.firstname);
                command.Parameters.AddWithValue("@username", user.username);
                command.Parameters.AddWithValue("@position", user.position);
                command.Parameters.AddWithValue("@password", user.password);
                command.Parameters.AddWithValue("@nic", user.nic);
                command.Parameters.AddWithValue("@phone", user.phone);
                command.Parameters.AddWithValue("@email", user.email);
                command.Parameters.AddWithValue("@id", user.id);

                await command.ExecuteNonQueryAsync();
            }
            return "Update Succesfully";
        }

        public async Task<string> DeleteUser(Guid userid)
        {
            using(var Connection = new SqlConnection(connectionString))
            {
                await Connection.OpenAsync();
                var command = Connection.CreateCommand();
                command.CommandText = @"
                         DELETE Users 
                         WHERE id=@id;
                ";
                command.Parameters.AddWithValue("@id", userid);
             await command.ExecuteNonQueryAsync();
            };
            return "Deleted SuccesFully";
        }






    }
}
