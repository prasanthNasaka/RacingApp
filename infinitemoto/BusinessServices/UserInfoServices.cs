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

            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(wReq.password);

                var userEntity = new Userinfo
                {
                    Username = wReq.username,
                    Password = hashedPassword,
                    Usertype = (int)wReq.usertype,
                    Compid = wReq.compid
                };

                await _dbContext.Userinfos.AddAsync(userEntity);
                await _dbContext.SaveChangesAsync();

                var result = new UserInfoDto
                {
                    id = userEntity.Id,
                    username = userEntity.Username,
                    usertype = (UserRoles)userEntity.Usertype,
                    compid = userEntity.Compid,
                    password = wReq.password
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

    }
}
