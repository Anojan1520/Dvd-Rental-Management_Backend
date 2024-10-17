
using System.Data.SqlClient;
using WebApplication1.IRepositroy;
using WebApplication1.Modals;

namespace WebApplication1.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private string connectionString;

        public LoginRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<string> UserLogin(Login detail)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = @"
                        INSERT INTO LoginUsers(id,username,password)
                        VALUES (@id,@username,@password);
                ";
                command.Parameters.AddWithValue("@id", detail.id);
                command.Parameters.AddWithValue("@username", detail.Username);
                command.Parameters.AddWithValue("@password", detail.password);
                command.ExecuteNonQuery();
            }
            return "Login Succesfully..";
        }

        public async Task<string> UpdateLogin(Guid id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var command = sqlConnection.CreateCommand();
                command.CommandText = @"
                        UPDATE LoginUsers
                        SET id=@id
                        WHERE id=@id
                ";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            return "LoginSuccessfull";
        }
        public async Task<string> Logout(Guid id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var command = sqlConnection.CreateCommand();
                command.CommandText = @"
                    DELETE LoginUsers
                    WhERE id=@id;
                ";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
            return "Logout Succesfull";
        }
        public async Task<List<Login>> GetLoginDetails()
        {
            var LoginList = new List<Login>();
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = @"
                        SELECT id,username,password from LoginUsers
                ";
                var Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    var obj = new Login
                    {
                        id = Reader.GetGuid(0),
                        Username = Reader.GetString(1),
                        password = Reader.GetString(2)
                    };
                    LoginList.Add(obj);
                }
            }
            return LoginList;
        }

    }
}
