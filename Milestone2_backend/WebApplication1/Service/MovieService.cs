using Microsoft.AspNetCore.Mvc;
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
                throw new ArgumentNullException("Movie Image is required");
            }
            string imagepaths = await _image.SaveImage(movie.Images, movie.Name);
            if (movie.Price<1)
            {
                throw new Exception("Enter a positive movie price");
            }
            if (movie.Quantity < 0)
            {
                throw new Exception("Enter a positive value for movie quantity");
            }

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

        public async Task<List<MovieResponse>> GetAllMovies()
        {
            var data = await _MovieRepo.GetAllMovies();
            var movielist = new List<MovieResponse>();
            foreach (var movie in data)
            {
                var imglist = new List<string>();
                foreach (var im in movie.Images.Split(","))
                {
                    imglist.Add(im);
                }
                movielist.Add(new MovieResponse
                {
                    id = movie.id,
                    Name = movie.Name,
                    Genere = movie.Genere,
                    Director = movie.Director,
                    Actor = movie.Actor,
                    Images = imglist,
                    Quantity = movie.Quantity,
                    Price = movie.Price,
                    Release = movie.Release,
                });
            }
           
            return movielist;
        }

        public async Task<MovieResponse> GetMovieById(Guid id)
        {
            var data = await _MovieRepo.GetMovieById(id);
            var imglist = new List<string>();
            foreach (var im in data.Images.Split(",")) 
            {
                imglist.Add(im);
            }
            return new MovieResponse
            {
                id = data.id,
                Name = data.Name,
                Genere = data.Genere,
                Director = data.Director,
                Actor = data.Actor,
                Images = imglist,
                Quantity = data.Quantity,
                Price = data.Price,
                Release = data.Release,
            };
        }

        public async Task<string> updateMovie( MovieRequest movie, Guid id)
        {
            if (movie.Price < 1)
            {
                throw new Exception("Enter a positive movie price");
            }
            if (movie.Quantity < 0)
            {
                throw new Exception("Enter a positive value for movie quantity");
            }
            var olddata = await _MovieRepo.GetMovieById(id);
            var movieobj = new Movies
            {
                id = id,
                Name = movie.Name,
                Genere = movie.Genere,
                Director = movie.Director,
                Actor = movie.Actor,
                Images = olddata.Images,
                Quantity = movie.Quantity,
                Price = movie.Price,
                Release = movie.Release,
            };
            var response = await _MovieRepo.updateMovie(movieobj);
            return response;
        }

        public async Task<string> deleteMovie(Guid id)
        {
            var olddata = await _MovieRepo.GetMovieById(id);
            if (olddata == null)
            {
                throw new Exception("Invalid id");
            }
            _image.Deleteimg(olddata.Images);
            var response = await _MovieRepo.deleteMovie(id);
            return response;
        }
              

    }
}
