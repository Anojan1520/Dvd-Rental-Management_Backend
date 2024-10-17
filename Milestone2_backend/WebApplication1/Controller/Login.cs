using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO.Request;
using WebApplication1.IService;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        private ILoginService _LoginService;
        public Login(ILoginService login)
        {
            _LoginService = login;
        }

        [HttpPost("User")]
        public async Task<IActionResult> LoginUser(LoginRequest LoginDetails)
        {
            try
            {
                var data = await _LoginService.LoginCustomer(LoginDetails);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("User")]
        public async Task<IActionResult> LogoutUser(Guid id)
        {
            try
            {
                var data = await _LoginService.Logout(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("User")]
        public async Task<IActionResult> GetAllLogin()
        {
            try
            {
                var data = await _LoginService.GetLoginDetails();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
