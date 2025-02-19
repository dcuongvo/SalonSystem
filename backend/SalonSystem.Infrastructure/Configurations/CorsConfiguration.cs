using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SalonSystem.Infrastructure.Configurations
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedOrigins = configuration.GetSection("AllowedOrigins").Get<string[]>();

            Console.WriteLine($"allowOrigins");

            // Fallback to allow all origins during development if no origins are defined
            if (allowedOrigins == null || !allowedOrigins.Any())
            {
                allowedOrigins = new[] { "*" }; // Use '*' only for development, not production
            }

            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", builder =>
                {
                    if (allowedOrigins.Contains("*"))
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    }
                    else
                    {
                        builder.WithOrigins(allowedOrigins)
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    }
                });
            });

            return services;
        }
    }
}
