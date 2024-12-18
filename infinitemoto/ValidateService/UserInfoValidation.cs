using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using infinitemoto.DTOs;

namespace infinitemoto.ValidateService
{

    public interface IUserInfoValidation
    {
        string ValidateUserInfo(UserInfoDto wReq);
    }
    public class UserInfoValidation : IUserInfoValidation
    {

        public string ValidateUserInfo(UserInfoDto request)
        {
            if (request == null)
            {
                return "User data is required.";
            }

            if (string.IsNullOrWhiteSpace(request.username))
            {
                return "Username is required.";
            }

            if (string.IsNullOrWhiteSpace(request.password))
            {
                return "Password is required.";
            }

            string passwordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

            if (!Regex.IsMatch(request.password, passwordPattern))
            {
                return "Password must contain at least one uppercase letter, one lowercase letter, one digit, one special character, and be at least 8 characters long.";
            }

            if (request.usertype==0)
            {
                return "Usertype is required.";
            }

            if (request.compid==0)
            {
                return "CompId is required.";
            }

            return "";

        }

    }
}