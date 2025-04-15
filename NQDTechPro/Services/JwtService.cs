using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NQDTechPro.Data;
using NQDTechPro.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NQDTechPro.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JwtService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            var expireMinutes = Convert.ToDouble(jwtSettings["ExpireMinutes"]);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Role", user?.Role ?? "user"),
            };

            var tokenDescriptor = new SecurityTokenDescriptor{

                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        private string GetTokenFromRequest()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                return authorizationHeader.Substring("Bearer ".Length);
            }
            return null;
        }
        public string GetUserIdFromToken()
        {
            string token = GetTokenFromRequest();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "nameid"); 
            return userIdClaim.Value;
        }

        public List<string> GetUserRolesFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var roleClaims = jwtToken.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            return roleClaims;
        }
    }
}
