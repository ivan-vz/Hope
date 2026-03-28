using FluentValidation.Results;
using Hope.Application.Interfaces;
using Hope.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hope.Application.Services
{
    public class TokenService(IConfiguration conf, UserManager<User> userManager) : ITokenService
    {
        private readonly IConfiguration _configuration = conf;
        private readonly UserManager<User> _userManager = userManager;

        public async Task<(string?, ValidationResult)> Create(User user)
        {
            var validation = new ValidationResult();

            var tokenKey = _configuration["TokenKey"]; 
            if (tokenKey is null || tokenKey.Length < 64) 
            { 
                validation.Errors.Add(new FluentValidation.Results.ValidationFailure("tokenKey", "invalid data")); 
                return (null, validation);
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Email, user.Email!)
            };
            
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return (tokenHandler.WriteToken(token), validation);
        }
    }
}
