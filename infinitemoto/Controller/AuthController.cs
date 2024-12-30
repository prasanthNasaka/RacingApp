using infinitemoto.BusinessServices;
using infinitemoto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using infinitemoto.DTOs;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace infinitemoto.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DummyProjectSqlContext _context;
        private readonly JwtService _jwtService;

        public AuthController(DummyProjectSqlContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(DTOs.RegisterRequest dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Username))
                return BadRequest("User already exists.");

            var user = new User
            {
                Email = dto.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)

            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(DTOs.Login dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return Unauthorized("Invalid username or password.");

            var token = _jwtService.GenerateToken(user.Email);
            return Ok(new { Token = token });
        }

        [HttpGet("validate-token")]
        public async Task<IActionResult> ValidateToken([FromQuery] string username)
        {
            var token = _jwtService.GenerateToken(username);
            var userToken = new Usertoken
            {
                
                Username = username,
                Password = "defaultPassword", // Set a default or generated password
                Token = token,
                CreatedAt = DateTime.UtcNow
            };
            // Store the token in the database
            _context.Usertokens.Add(userToken);
            await _context.SaveChangesAsync();
            return Ok(new { Token = token });
        }
    }
}
