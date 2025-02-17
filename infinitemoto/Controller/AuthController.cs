using Microsoft.AspNetCore.Mvc;
using infinitemoto.BusinessServices;
using System.Security.Claims;

namespace infinitemoto.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private const string DefaultUsername = "admin";
        private const string DefaultPassword = "moto@123";

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        // Login action to authenticate user and return a JWT token
        [HttpPost("login")]
        public IActionResult Login(DTOs.Login dto)
        {
            // Check if credentials are valid
            if (dto.Username == DefaultUsername && dto.Password == DefaultPassword)
            {
                // Generate token after successful login
                var token = _jwtService.GenerateToken(DefaultUsername);
                return Ok(new { Token = token });
            }

            // Unauthorized if credentials are invalid
            return Unauthorized("Invalid username or password.");
        }

        // Validate token action (for checking the token)
        [HttpGet("validate-token")]
        public IActionResult ValidateToken([FromQuery] string token)
        {
            // Here, validate the incoming token instead of username
            var principal = _jwtService.ValidateToken(token);
            if (principal == null)
            {
                return Unauthorized("Invalid or expired token.");
            }

            // Return the claims or user info from the valid token
            var username = principal.FindFirst(ClaimTypes.Name)?.Value;
            return Ok(new { Username = username });
        }
    }
}
