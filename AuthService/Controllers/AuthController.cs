using AuthService.DTOs;
using AuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
        //     try
        //     {
                var token = await _authService.Login(dto);
                return Ok(new { token });
        //     }
        //     catch (UnauthorizedAccessException ex)
        //     {
        //         return Unauthorized(new { message = ex.Message });
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(new { message = ex.Message });
        //     }
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            // try
            // {
                await _authService.Register(dto);
                return Ok(new { message = "User registered successfully." });
            // }
            // catch (Exception ex)
            // {
            //     return BadRequest(new { message = ex.Message });
            // }
        }
    }
}
