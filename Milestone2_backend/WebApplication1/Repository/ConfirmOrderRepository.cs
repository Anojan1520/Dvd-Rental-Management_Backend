using System.Data.SqlClient;
using WebApplication1.IRepository;
using WebApplication1.Modals;

namespace WebApplication1.Repository
{
    public class ConfirmOrderRepository : IConfirmOrderRepository
    {
        private string _connectionString;

        public ConfirmOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public string AddConfirmOrder(ConfirmOrders confirmOrders)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                                        INSERT INTO ConfirmOrders(id, Movie, TotalRent, UserId, RentedDate, ReturnDate, MovieId)
                                        VALUES(@id, @Movie, @TotalRent, @UserId, @RentedDate, @ReturnDate, @MovieId);
                                        ";

                command.Parameters.AddWithValue("@id", Guid.NewGuid());
                command.Parameters.AddWithValue("@Movie", confirmOrders.Movie);
                command.Parameters.AddWithValue("@TotalRent", confirmOrders.TotalRent);
                command.Parameters.AddWithValue("@UserId", confirmOrders.UserId);
                command.Parameters.AddWithValue("@RentedDate", confirmOrders.RentedDate);
                command.Parameters.AddWithValue("@ReturnDate", confirmOrders.ReturnDate);
                command.Parameters.AddWithValue("@MovieId", confirmOrders.MovieId);

                command.ExecuteNonQuery();

            }
            return "ConfirmOrder Added SuccessFully....";
        }

        public List<ConfirmOrders> GetConfirmOrders()
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM ConfirmOrders";

                var listconfirmorder = new List<ConfirmOrders>();
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var obj = new ConfirmOrders
                        {
                            id = reader.GetGuid(0),
                            Movie = reader.GetString(1),
                            TotalRent = reader.GetInt32(2),
                            UserId = reader.GetGuid(3),
                            RentedDate = reader.GetString(4),
                            ReturnDate = reader.GetString(5),
                            MovieId = reader.GetGuid(6)

                        };

                        listconfirmorder.Add(obj);
                    }
                    return listconfirmorder;

                }
            }
        }



        public string DeleteConfirmOrder(Guid confirmOrderId)
        {
            using( var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                                        DELETE ConfirmOrders
                                        WHERE id = @id";

                command.Parameters.AddWithValue("@id", confirmOrderId);

                command.ExecuteNonQuery();
            }
            return "ConfirmOrder Deleted Successfully";

        }


        public string UpdateConfirmorder(ConfirmOrders confirmorder)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE ConfirmOrders
                                        SET  Movie = @Movie, 
                                        TotalRent = @TotalRent,
                                        UserId = @UserId,
                                        RentedDate = @RentedDate,
                                        ReturnDate = @ReturnDate,
                                        MovieId = @MovieId
                                        WHERE id = @id;";

                command.Parameters.AddWithValue("@id", confirmorder.id);
                command.Parameters.AddWithValue("@Movie", confirmorder.Movie);
                command.Parameters.AddWithValue("@TotalRent", confirmorder.TotalRent);
                command.Parameters.AddWithValue("@UserId", confirmorder.UserId);
                command.Parameters.AddWithValue("@RentedDate", confirmorder.RentedDate);
                command.Parameters.AddWithValue("@ReturnDate", confirmorder.ReturnDate);
                command.Parameters.AddWithValue("@MovieId", confirmorder.MovieId);

                command.ExecuteNonQuery();
                                        
            }

            return "ConfirmOrder Updated successfully..";
        }
        
    }
}
