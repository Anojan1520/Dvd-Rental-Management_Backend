using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebApplication1.DTO.Request;
using WebApplication1.IService;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("User")]
        public async Task<IActionResult> Register(UserRequest users)
        {
            try
            {
                var ReturnData = await userService.Register(users);
                return Ok(ReturnData);
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data =await userService.GetAllUser();
                return Ok(data);
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("User")]
        public async Task<IActionResult> UpdateUser(UserRequest user, Guid id)
        {
            try
            {
                var data = await userService.UpdateUser(user, id);
                return Ok(data);
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("User/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var data =await userService.DeleteUser(id);
                return Ok(data);
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message) ;
            }
        }
    }
}
