using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SalonSystem.Infrastructure.Configurations; 
using SalonSystem.Infrastructure.Data;
//Repositoroes
using SalonSystem.Infrastructure.Repositories.Appointments.Interfaces;
using SalonSystem.Infrastructure.Repositories.Appointments.Implementations;
using SalonSystem.Infrastructure.Repositories.Salons.Interfaces;
using SalonSystem.Infrastructure.Repositories.Salons.Implementations;
using SalonSystem.Infrastructure.Repositories.Technicians.Interfaces;
using SalonSystem.Infrastructure.Repositories.Technicians.Implementations;
using SalonSystem.Infrastructure.Repositories.Users.Interfaces;
using SalonSystem.Infrastructure.Repositories.Users.Implementations;
using SalonSystem.Infrastructure.Repositories.Services.Interfaces;
using SalonSystem.Infrastructure.Repositories.Services.Implementations;
//Services
using SalonSystem.Application.Services.Users.Interfaces;
using SalonSystem.Application.Services.Users.Implementations;
using SalonSystem.Application.Services.Authentication.Interfaces;
using SalonSystem.Application.Services.Authentication.Implementations;
using SalonSystem.Application.Services.Salons.Interfaces;
using SalonSystem.Application.Services.Salons.Implementations;
var builder = WebApplication.CreateBuilder(args);

// Load User Secrets during development
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}


// Debug: Log JwtSettings to verify configuration values
Console.WriteLine("==========================================");
Console.WriteLine($"Jwt Key: {builder.Configuration["JwtSettings:Key"]}");
Console.WriteLine($"Jwt Issuer: {builder.Configuration["JwtSettings:Issuer"]}");
Console.WriteLine($"Jwt Audience: {builder.Configuration["JwtSettings:Audience"]}");

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Salon System API",
        Version = "v1",
        Description = "API documentation for the Salon System",
    });
});

// Configure DbContext
builder.Services.AddDbContext<SalonSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register JWT Authentication from Infrastructure Layer
builder.Services.AddJwtAuthentication(builder.Configuration);

// Register CORS from Infrastructure Layer
builder.Services.AddCustomCors(builder.Configuration);
// Register Repositories
RegisterRepositories(builder.Services);

// Register Services
RegisterServices(builder.Services);

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Salon System API v1");
        options.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
    });
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapControllers();
app.Run();

// Helper method to register repositories
void RegisterRepositories(IServiceCollection services)
{
    // Appointments
    services.AddScoped<IAppointmentRepository, AppointmentRepository>();
    services.AddScoped<ITimeBlockRepository, TimeBlockRepository>();

    // Salons
    services.AddScoped<ISalonRepository, SalonRepository>();
    services.AddScoped<ISalonScheduleRepository, SalonScheduleRepository>();

    // Technicians
    services.AddScoped<ITechnicianRepository, TechnicianRepository>();
    services.AddScoped<ITechnicianScheduleRepository, TechnicianScheduleRepository>();

    // Users
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<ISubUserRepository, SubUserRepository>();

    // Services
    services.AddScoped<IServiceRepository, ServiceRepository>();
    services.AddScoped<ISkillRepository, SkillRepository>();
    services.AddScoped<IServiceSkillRepository, ServiceSkillRepository>();
}

// Helper method to register services
void RegisterServices(IServiceCollection services)
{
    // Uncomment when services are ready to be registered
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IAuthenticationService, AuthenticationService>();
    services.AddScoped<ISalonService, SalonService>();
    // services.AddScoped<ITechnicianService, TechnicianService>();
    // services.AddScoped<IAppointmentService, AppointmentService>();
    // services.AddScoped<ITimeBlockService, TimeBlockService>();
    // services.AddScoped<ISkillService, SkillService>();
}
