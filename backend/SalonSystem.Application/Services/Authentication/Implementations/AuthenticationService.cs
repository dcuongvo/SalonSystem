using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SalonSystem.Domain.Entities.Users;
using SalonSystem.Infrastructure.Repositories.Users.Interfaces;
using SalonSystem.Application.Services.Authentication.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace SalonSystem.Application.Services.Authentication.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string?> LoginUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null) return null;

            using var hmac = new HMACSHA512(Convert.FromBase64String(user.PasswordSalt!));
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            if (Convert.ToBase64String(computedHash) != user.PasswordHash) return null;

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            Console.WriteLine(jwtSettings["Key"]);
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

            var claims = new[]
            {
                new System.Security.Claims.Claim("id", user.UserId.ToString()),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Username),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, "User")
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
