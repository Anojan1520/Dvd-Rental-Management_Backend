using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.IRepositroy;
using WebApplication1.IService;
using WebApplication1.Modals;

namespace WebApplication1.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _MovieRepo;
        private readonly IMovieImage _image;

        public MovieService(IMovieRepository movieRepo, IMovieImage image)
        {
            _MovieRepo = movieRepo;
            _image = image;
        }

        public async Task<string> AddMovie(MovieRequest movie)
        {
            if (movie.Images.Count == 0)
            {
                throw new ArgumentException("Movie Image is required");
            }
           
            string imagepaths = await _image.SaveImage(movie.Images, movie.Name);

            var obj = new Movies
            {
                Name = movie.Name,
                Genere = movie.Genere,
                Director = movie.Director,
                Actor = movie.Actor,
                Images = imagepaths,
                Quantity = movie.Quantity,
                Price = movie.Price,
                Release = movie.Release,
            };

            var response = await _MovieRepo.AddMovie(obj);
            return response;
        }

        //public async Task<List<MovieResponse>> GetAllMovies()
        //{
        //    var data = await _MovieRepo.GetAllMovies();
        //    var response = data.Select(d => new MovieResponse
        //    {
        //        id = d.id,
        //        Name = d.Name,
        //        Genere = d.Genere,
        //        Director = d.Director,
        //        Actor = d.Actor,
        //        Images = d.Images,
        //        Quantity = d.Quantity,
        //        Price = d.Price,
        //        Release = d.Release,
        //    }).ToList();

        //    return response;
        //}

        //public async Task<MovieResponse> GetMovieById(Guid id)
        //{
        //    var data = await _MovieRepo.GetMovieById(id);
        //    return new MovieResponse
        //    {
        //        id = data.id,
        //        Name = data.Name,
        //        Genere = data.Genere,
        //        Director = data.Director,
        //        Actor = data.Actor,
        //        Images = data.Images,
        //        Quantity = data.Quantity,
        //        Price = data.Price,
        //        Release = data.Release,
        //    };
        //}

        //public async Task<string> updateMovie(MovieRequest movie, Guid id)
        //{
        //    var movieobj = new Movies
        //    {
        //        id = id,
        //        Name = movie.Name,
        //        Genere = movie.Genere,
        //        Director = movie.Director,
        //        Actor = movie.Actor,
        //        Images = movie.Images,
        //        Quantity = movie.Quantity,
        //        Price = movie.Price,
        //        Release = movie.Release,
        //    };

        //    var response = await _MovieRepo.updateMovie(movieobj);
        //    return response;
        //}

        //public async Task<string> deleteMovie(Guid id)
        //{
        //    var response = await _MovieRepo.deleteMovie(id);
        //    return response;
        //}

    }
}
