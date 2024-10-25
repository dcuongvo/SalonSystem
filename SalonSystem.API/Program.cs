using SalonSystem.Data;
using Microsoft.EntityFrameworkCore;
using SalonSystem.Data.Repositories;
using SalonSystem.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add Repositories
builder.Services.AddScoped<ISalonRepository, SalonRepository>();
builder.Services.AddScoped<ITechnicianRepository, TechnicianRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();

// Add Services
builder.Services.AddScoped<SalonService>();
builder.Services.AddScoped<TechnicianService>();
builder.Services.AddScoped<SkillService>();
builder.Services.AddScoped<ServiceService>();

// Add DbContext
builder.Services.AddDbContext<SalonSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SalonSystemDb")));

// Configure JSON serializer options (to retain property naming as defined in C#)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.PropertyNamingPolicy = null);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOrigins",
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline
/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/
app.UseCors("AllowedOrigins");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
