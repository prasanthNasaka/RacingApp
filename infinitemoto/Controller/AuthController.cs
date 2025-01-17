using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using infinitemoto.BusinessServices;

namespace infinitemoto.controller
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

        [HttpPost("login")]
        public IActionResult Login(DTOs.Login dto)
        {
            if (dto.Username == DefaultUsername && dto.Password == DefaultPassword)
            {
                var token = _jwtService.GenerateToken(DefaultUsername);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username or password.");
        }

        [HttpGet("validate-token")]
        public IActionResult ValidateToken([FromQuery] string username)
        {
            if (username == DefaultUsername)
            {
                var token = _jwtService.GenerateToken(username);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username.");
        }
    }
}
