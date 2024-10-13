using WebApplication1.Modals;

namespace WebApplication1.IRepositroy
{
    public interface IMovieRepository
    {
        Task<string> AddMovie(Movies movie);
        Task<List<Movies>> GetAllMovies();
        Task<Movies> GetMovieById(Guid id);
        Task<string> updateMovie(Movies movie);
        Task<string> deleteMovie(Guid id);
    }
}
