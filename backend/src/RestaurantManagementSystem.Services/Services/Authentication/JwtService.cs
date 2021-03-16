using Microsoft.IdentityModel.Tokens;
using RestaurantManagementSystem.Services.Entities;
using RestaurantManagementSystem.Services.Interfaces.Models;
using RestaurantManagementSystem.Services.Interfaces.Services.Authentication;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantManagementSystem.Services.Services.Authentication
{
    /// <summary>
    /// JSON Web Token Service
    /// </summary>
    public class JwtService : ITokenService
    {
        private readonly IAppSettings _appSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="JwtService"/> class
        /// </summary>
        /// <param name="appSettings">Instance of <see cref="IAppSettings"/></param>
        public JwtService(IAppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        /// <summary>
        /// Generates and returns the Authentication Token for the user
        /// </summary>
        /// <param name="user">User regarding the token to be created</param>
        /// <returns>Token</returns>
        public string GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.JwtSecret);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = GetClaimsIdentity(user),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandle = new JwtSecurityTokenHandler();
            var token = tokenHandle.CreateToken(tokenDescription);
            return tokenHandle.WriteToken(token);
        }

        private ClaimsIdentity GetClaimsIdentity(User user)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Username));
            claims.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            foreach (var role in user.Roles)
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));
            }

            return claims;
        }
    }
}
