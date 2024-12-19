using infinitemoto.DTOs;
using infinitemoto.LookUps;
using infinitemoto.Models;
using infinitemoto.Results;
using infinitemoto.ValidateService;
using Microsoft.EntityFrameworkCore;

namespace infinitemoto.BusinessServices
{
    public interface IUserInfoServices
    {
        Task<Result<UserInfoDto>> CreateAsync(UserInfoDto wReq);
        Task<Result<bool>> UpdatePasswordAsync(ForgotPasswordDto request);
    }

    public class UserInfoServices : IUserInfoServices
    {
        private readonly DummyProjectSqlContext _dbContext;
        private readonly IUserInfoValidation userInfoValidation;

        public UserInfoServices(DummyProjectSqlContext dbContext, IUserInfoValidation _userInfoValidation)
        {
            _dbContext = dbContext;
            userInfoValidation = _userInfoValidation;
        }

        public async Task<Result<UserInfoDto>> CreateAsync(UserInfoDto wReq)
        {
            var errors = userInfoValidation.ValidateUserInfo(wReq);
            if (!string.IsNullOrEmpty(errors))
                return Result<UserInfoDto>.Fail(errors);

            // Add role-specific validation
            if (wReq.usertype == AuthenticationRoles.Admin) // Admin
            {
                // Check if there's already an admin for this company
                var existingAdmin = await _dbContext.Userinfos
                    .AnyAsync(u => u.Compid == wReq.compid && u.Usertype == 2);

                if (existingAdmin)
                {
                    return Result<UserInfoDto>.Fail("An admin already exists for this company.");
                }
            }

            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(wReq.password);
                var userEntity = new Userinfo
                {
                    Username = wReq.username,
                    Password = hashedPassword,
                    Usertype = (int)wReq.usertype,
                    Compid = wReq.compid,
                    IsActive = wReq.isActive
                };

                await _dbContext.Userinfos.AddAsync(userEntity);
                await _dbContext.SaveChangesAsync();

                var result = new UserInfoDto
                {
                    id = userEntity.Id,
                    username = userEntity.Username,
                    usertype = (AuthenticationRoles)userEntity.Usertype,
                    compid = userEntity.Compid,
                    password = wReq.password,
                    isActive = userEntity.IsActive
                };

                return Result<UserInfoDto>.Success(result);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Database update error: {dbEx.Message}");
                return Result<UserInfoDto>.Fail("An error occurred while saving the user. Please check the input data.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return Result<UserInfoDto>.Fail("An unexpected error occurred while creating the user.");
            }
        }

        public async Task<Result<bool>> UpdatePasswordAsync(ForgotPasswordDto request)
        {
            try
            {
                var user = await _dbContext.Userinfos
                    .FirstOrDefaultAsync(u => u.Username == request.Username && u.IsActive);

                if (user == null)
                {
                    return Result<bool>.Fail("User not found or inactive.");
                }

                // Hash the new password
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
                user.Password = hashedPassword;

                await _dbContext.SaveChangesAsync();
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return Result<bool>.Fail("An unexpected error occurred while updating the password.");
            }
        }
    }
}
