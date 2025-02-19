using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SalonSystem.Infrastructure.Configurations
{
    public static class JwtConfiguration
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {


            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = jwtSettings.GetValue<string>("Key");
            var audience = jwtSettings.GetValue<string>("Audience");
            var issuer = jwtSettings.GetValue<string>("Issuer");
            if (string.IsNullOrEmpty(key) || key.Length < 32)
            {
                throw new ArgumentException("The JWT key must be at least 32 characters long.");
            }

            var keyBytes = Encoding.UTF8.GetBytes(key);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
                };
            });

            return services;
        }
    }
}
