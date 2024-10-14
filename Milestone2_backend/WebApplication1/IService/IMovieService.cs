using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;

namespace WebApplication1.IService
{
    public interface IMovieService
    {
        Task<string> AddMovie(MovieRequest movie);
        Task<List<MovieResponse>> GetAllMovies();
        Task<MovieResponse> GetMovieById(Guid id);
        Task<string> updateMovie(MovieRequest movie, Guid id);
        Task<string> deleteMovie(Guid id);
    }
}
