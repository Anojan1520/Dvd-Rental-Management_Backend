using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
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


        [HttpPost("Movie")]
        public async Task<IActionResult> AddMovie([FromForm]MovieRequest movie)
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
            catch(SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Movie")]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                var data = await _movieService.GetAllMovies();
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("Movie/{id}")]
        public async Task<IActionResult> GetMovieById(Guid id)
        {
            try
            {
                var data = await _movieService.GetMovieById(id);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Movie/{id}")]
        public async Task<IActionResult> updateMovie([FromBody] MovieRequest movie, Guid id)
        {
            try
            {
                var data = await _movieService.updateMovie(movie, id);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Movie/{id}")]
        public async Task<IActionResult> deleteMovie(Guid id)
        {
            try
            {
                var data = await _movieService.deleteMovie(id);
                return Ok(data);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
