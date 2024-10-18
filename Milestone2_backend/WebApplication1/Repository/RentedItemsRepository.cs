using System.Data.SqlClient;
using WebApplication1.IRepository;
using WebApplication1.Modals;

namespace WebApplication1.Repository
{
    public class RentedItemsRepository : IRentedItemsRepository
    {

        private string _connectionString;

        public RentedItemsRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public string AddRentedItems(RentedItems rentedItems)
        {
            if (rentedItems!=null)
            {
                using (var connectionString = new SqlConnection(_connectionString))
                {
                    connectionString.Open();
                    var command = connectionString.CreateCommand();
                    command.CommandText = @"
                            INSERT INTO RentedItems(id, MovieId, UserId, Status, RentedQuantity, RentDate, ReturnDate) 
                            VALUES(@id, @MovieId, @UserId, @Status , @RentedQuantity, @RentDate , @ReturnDate)";
                    command.Parameters.AddWithValue("@id", Guid.NewGuid());
                    command.Parameters.AddWithValue("@MovieId", rentedItems.MovieId);
                    command.Parameters.AddWithValue("@UserId", rentedItems.UserId);
                    command.Parameters.AddWithValue("@Status", rentedItems.Status);
                    command.Parameters.AddWithValue("@RentedQuantity", rentedItems.RentedQuantity);
                    command.Parameters.AddWithValue("@RentDate", rentedItems.RentedDate);
                    command.Parameters.AddWithValue("@ReturnDate", rentedItems.ReturnDate);


                    command.ExecuteNonQuery();

                }
                return "RentedItems save Successfully..";
            }
            else
            {
                throw new Exception("RentedItems Required");
            }
            
        }



        public List<RentedItems> GetAllRentedItems()
        {
            using (var connectionString = new SqlConnection(_connectionString))
            {
                connectionString.Open();
                var command = connectionString.CreateCommand();
                command.CommandText = @"SELECT * FROM RentedItems";
                var RentedItem = new List<RentedItems>();
                using (var item = command.ExecuteReader())
                {
                    while (item.Read())
                    {
                        var obj = new RentedItems
                        {
                            Id = item.GetGuid(0),
                            MovieId = item.GetGuid(1),
                            UserId = item.GetGuid(2),
                            Status = item.GetString(3),
                            RentedQuantity = item.GetInt32(4),
                            RentedDate = item.GetString(5),
                            ReturnDate = item.GetString(6),
                           
                        };
                        RentedItem.Add(obj);

                    };
                    return RentedItem;
                } 
            }
        }

        public async Task<string> UpdateRentedItems(RentedItems rentedItems)
        {
            if (rentedItems != null)
            {
                using (var Connection = new SqlConnection(_connectionString))
                {
                    await Connection.OpenAsync();

                    var command = Connection.CreateCommand();
                    command.CommandText = @"
                        UPDATE RentedItems
                        SET MovieId=@MovieId , 
                           UserId=@UserId ,
                           Status=@Status, 
                           RentedQuantity=@RentedQuantity,
                           RentDate=@RentDate,
                           ReturnDate=@ReturnDate
                        WHERE id=@id
                                    ";
                    command.Parameters.AddWithValue("@id", rentedItems.Id);
                    command.Parameters.AddWithValue("@MovieId", rentedItems.MovieId);
                    command.Parameters.AddWithValue("@UserId", rentedItems.UserId);
                    command.Parameters.AddWithValue("@Status", rentedItems.Status);
                    command.Parameters.AddWithValue("@RentedQuantity", rentedItems.RentedQuantity);
                    command.Parameters.AddWithValue("@RentDate", rentedItems.RentedDate);
                    command.Parameters.AddWithValue("@ReturnDate", rentedItems.ReturnDate);

                    await command.ExecuteNonQueryAsync();
                }
                return "Update Succesfully";
            }
            else
            {
                throw new Exception("RentedItems Required");
            }

        }


        public string DeleteRentedItem(Guid id)
        {

            using (var connectionString = new SqlConnection(_connectionString))
            {
                connectionString.Open();
                var command = connectionString.CreateCommand();
                command.CommandText = @" DELETE RentedItem
                                         WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

            }
            return "RentedItem deleted SuccessFully....";
        }

    }


}
