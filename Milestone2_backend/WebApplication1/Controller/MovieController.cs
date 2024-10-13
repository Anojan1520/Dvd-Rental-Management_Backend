using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Request;
using WebApplication1.IService;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpPost("Add_Movie")]
        public async Task<IActionResult> AddMovie(MovieRequest movie)
        {
            try
            {
                if (movie == null)
                {
                    return BadRequest("movie details is required");
                }

                var data = await _movieService.AddMovie(movie);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpGet("get_All-Movies")]
        //public async Task<IActionResult> GetAllMovies()
        //{
        //    try
        //    {
        //        var data = await _movieService.GetAllMovies();
        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}


        //[HttpGet("get-Movie-byId")]
        //public async Task<IActionResult> GetMovieById(Guid id)
        //{
        //    try
        //    {
        //        var data = await _movieService.GetMovieById(id);
        //        return Ok(data);
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        //[HttpPut("update-movie")]
        //public async Task<IActionResult> updateMovie(MovieRequest movie, Guid id)
        //{
        //    try
        //    {
        //        var data = await _movieService.updateMovie(movie, id);
        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        //[HttpDelete("delete-movie")]
        //public async Task<IActionResult> deleteMovie(Guid id)
        //{
        //    try
        //    {
        //        var data = await _movieService.deleteMovie(id);
        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


    }
}
