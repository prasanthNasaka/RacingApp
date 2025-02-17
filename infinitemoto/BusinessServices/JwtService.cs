using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static infinitemoto.BusinessServices.JwtService;

namespace infinitemoto.BusinessServices
{
    public class JwtService : IJwtService
    {
        private readonly string _key;
        private readonly string _issuer;

        private readonly string _audience;
        public JwtService(IConfiguration configuration)
        {
            _key = configuration["Jwt:Key"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
        }
        public string GenerateToken(string username)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: _issuer, audience: _audience, claims: claims, expires: DateTime.Now.AddHours(1), signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public ClaimsPrincipal ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_key);

            try
            {
                // Define validation parameters
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };

                // Validate the token
                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);

                // If token is valid, return the claims principal
                return principal;
            }
            catch (SecurityTokenException)
            {
                // Invalid token (e.g., expired, malformed, etc.)
                return null;
            }
            catch (Exception)
            {
                // Any other errors (e.g., bad key, etc.)
                return null;
            }
        }
    }
}




