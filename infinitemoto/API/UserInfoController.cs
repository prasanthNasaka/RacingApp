using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using infinitemoto.DTOs;
using infinitemoto.BusinessServices;

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

        [HttpPost("SignUP")]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserInfoDto request)
        {
            if (request == null)
            {
                return BadRequest("User data is required.");
            }

            if (string.IsNullOrWhiteSpace(request.username) || string.IsNullOrWhiteSpace(request.password))
            {
                return BadRequest("Username and password are required.");
            }

            try
            {
                UserInfoDto userInfoRequest = await userInfoServices.CreateAsync(request);

                return Ok(new
                {
                    Message = "User created successfully.",
                    Data = userInfoRequest
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "An error occurred while creating the user.",
                    Error = ex.Message
                });
            }
        }
    }
}
