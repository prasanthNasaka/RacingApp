using System;
using System.Threading.Tasks;
using BCrypt.Net;
using infinitemoto.DTOs;
using infinitemoto.Models;
using Microsoft.EntityFrameworkCore;

namespace infinitemoto.BusinessServices
{
    public interface IUserInfoServices
    {
        Task<UserInfoDto> CreateAsync(UserInfoDto wReq);
    }

    public class UserInfoServices : IUserInfoServices
    {
        private readonly DummyProjectSqlContext _dbContext;

        public UserInfoServices(DummyProjectSqlContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserInfoDto> CreateAsync(UserInfoDto wReq)
        {
            if (wReq == null)
                throw new ArgumentNullException(nameof(wReq), "User request cannot be null.");

            // Hash the password before saving
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(wReq.password);

            // Map DTO to Entity (UserInfo)
            var userEntity = new Userinfo
            {
                Username = wReq.username,
                Password = hashedPassword,
                Usertype = wReq.usertype,
                Compid = wReq.compid
            };

            // Add the new user entity to the DbContext
            await _dbContext.Userinfos.AddAsync(userEntity);
            
            // Save changes asynchronously
            await _dbContext.SaveChangesAsync();

            // Map the saved entity back to a DTO to return
            var userDto = new UserInfoDto
            {
                id = userEntity.Id,
                username = userEntity.Username,
                usertype = userEntity.Usertype,
                compid = userEntity.Compid
            };

            return userDto;
        }
    }
}
