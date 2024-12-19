using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using infinitemoto.DTOs;
using System.IdentityModel.Tokens.Jwt;

namespace infinitemoto.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>(); // Simulates user storage
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public ActionResult Register(UserDto request)
        {
            try
            {
                // Check if the user already exists
                if (_users.Exists(u => u.Username == request.Username))
                {
                    return Conflict(new
                    {
                        Message = "Username already exists."
                    });
                }

                // Hash the password
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

                // Create and save the user
                User user = new User
                {
                    Username = request.Username,
                    PasswordHash = passwordHash
                };
                _users.Add(user);

                return Ok(new
                {
                    Message = "User registered successfully.",
                    Username = user.Username
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while registering the user.",
                    Error = ex.Message
                });
            }
        }

        [HttpPost("login")]
        public ActionResult Login(UserDto request)
        {
            try
            {
                // Check if the user exists
                var user = _users.Find(u => u.Username == request.Username);
                if (user == null)
                {
                    return NotFound(new
                    {
                        Message = "User not found."
                    });
                }

                // Verify the password
                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                {
                    return Unauthorized(new
                    {
                        Message = "Incorrect password."
                    });
                }

                // Generate a JWT token
                string token = CreateToken(user);

                return Ok(new
                {
                    Message = "Login successful.",
                    Token = token
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while logging in.",
                    Error = ex.Message
                });
            }
        }

        private string CreateToken(User user)
        {
            // Create claims for the JWT
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            // Retrieve the secret key from configuration
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            // Define signing credentials
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            // Create the JWT token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
