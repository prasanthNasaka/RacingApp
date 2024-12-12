using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using infinitemoto.DTOs;
using infinitemoto.BusinessServices;
using System.Text.RegularExpressions;
using infinitemoto.Results;

namespace infinitemoto.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoServices userInfoServices;

        public UserInfoController(IUserInfoServices _userInfoServices)
        {
            userInfoServices = _userInfoServices;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserInfoDto request)
        {
            try
            {
                // Call the service to create the user
                Result<UserInfoDto> result = await userInfoServices.CreateAsync(request);

                // Check if the operation was successful
                if (result.IsSuccess)
                {
                    return Ok(new
                    {
                        Message = "User created successfully.",
                        Data = result.Data
                    });
                }
                else
                {
                    // Return a 400 Bad Request with the validation errors
                    return BadRequest(new
                    {
                        Message = "Validation error occurred.",
                        Error = result.Error
                    });
                }
            }
            catch (Exception ex)
            {
                // Log and return a 500 Internal Server Error
                Console.WriteLine($"Unexpected error: {ex.Message}");
                return StatusCode(500, new
                {
                    Message = "An unexpected error occurred while creating the user.",
                    Error = ex.Message
                });
            }
        }

    }
}
