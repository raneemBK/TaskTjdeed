using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTjdeed.Authentication;
using TaskTjdeed.DTOs;
using TaskTjdeed.Models;

namespace TaskTjdeed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                Phone = request.Phone,
                RoleName = "User"
            };

            var success = await _authService.Register(user, request.Password);
            if (!success) return BadRequest("Registration failed.");

            return Ok(new { message = "User registered successfully." });
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var token = await _authService.Login(request.Email, request.Password);
            if (token == null) return Unauthorized("Invalid credentials.");

            return Ok(new { token });
        }
        [HttpGet("TestToken")]
        public IActionResult TestToken()
        {
            return Ok(User.Claims.Select(c => new { c.Type, c.Value }));
        }

    }
}
