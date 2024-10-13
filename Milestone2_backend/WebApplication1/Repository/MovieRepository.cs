using System.Data.SqlClient;
using WebApplication1.IRepositroy;
using WebApplication1.Modals;

namespace WebApplication1.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string connectionString;

        public MovieRepository(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public async Task<string> AddMovie(Movies movie)
        {
                using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Movies(id,Name,Genere,Director,Actor,Images,Quantity,Price,Release)
                                           VALUES(@id,@Name,@Genere,@Director,@Actor,@Images,@Quantity,@Price,@Release)";
                command.Parameters.AddWithValue("@id", Guid.NewGuid());
                command.Parameters.AddWithValue("@Name", movie.Name);
                command.Parameters.AddWithValue("@Genere", movie.Genere);
                command.Parameters.AddWithValue("@Director", movie.Director);
                command.Parameters.AddWithValue("@Actor", movie.Actor);
                command.Parameters.AddWithValue("@Images", movie.Images);
                command.Parameters.AddWithValue("@Quantity", movie.Quantity);
                command.Parameters.AddWithValue("@Price", movie.Price);
                command.Parameters.AddWithValue("@Release", movie.Release);

                command.ExecuteNonQuery();
            }

            return "Movie Added Successfully...";
        }


        public async Task<List<Movies>> GetAllMovies()
        {
            var movies = new List<Movies>();
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM Movies";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movies
                        {
                            id = (Guid)reader["id"],
                            Name = (string)reader["Name"],
                            Genere = (string)reader["Genere"],
                            Director = (string)reader["Director"],
                            Actor = (string)reader["Actor"],
                            Images = (string)reader["Images"],
                            Quantity = (int)reader["Quantity"],
                            Price = (decimal)reader["Price"],
                            Release = (string)reader["Release"]
                        });
                    }
                }
            }
            return movies;
        }

        public async Task<Movies> GetMovieById(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM Movies WHERE id=@id";
                command.Parameters.AddWithValue("@id", id);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        return new Movies
                        {
                            id = (Guid)reader["id"],
                            Name = (string)reader["Name"],
                            Genere = (string)reader["Genere"],
                            Director = (string)reader["Director"],
                            Actor = (string)reader["Actor"],
                            Images = (string)reader["Images"],
                            Quantity = (int)reader["Quantity"],
                            Price = (decimal)reader["Price"],
                            Release = (string)reader["Release"]
                        };
                    }
                }
            }
            throw new ArgumentNullException("Invalid ID");
        }

        public async Task<string> updateMovie(Movies movie)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = @"UPDATE Movies SET Name=@Name,Genere=@Genere,Director=@Director ,
                                                          Actor=@Actor,Images=@Images,Quantity=@Quantity,Price=@Price,Release=@Release
                                                          WHERE id = @id";
                command.Parameters.AddWithValue("@id", movie.id);
                command.Parameters.AddWithValue("@Name", movie.Name);
                command.Parameters.AddWithValue("@Genere", movie.Genere);
                command.Parameters.AddWithValue("@Director", movie.Director);
                command.Parameters.AddWithValue("@Actor", movie.Actor);
                command.Parameters.AddWithValue("@Images", movie.Images);
                command.Parameters.AddWithValue("@Quantity", movie.Quantity);
                command.Parameters.AddWithValue("@Price", movie.Price);
                command.Parameters.AddWithValue("@Release", movie.Release);

                command.ExecuteNonQuery();
            }
            return "Movie is updated successfully";
        }

        public async Task<string> deleteMovie(Guid id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = @"DELETE  Movies WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
            return "Movie is deleted";
        }
    }
}
