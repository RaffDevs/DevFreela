using DevFreela.Application.Services;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string? server = Environment.GetEnvironmentVariable("DB_SERVER");
string? port = Environment.GetEnvironmentVariable("DB_PORT");
string? database = Environment.GetEnvironmentVariable("DB_DATABASE");
string? user = Environment.GetEnvironmentVariable("DB_USER");
string? password = Environment.GetEnvironmentVariable("DB_PASSWORD");
// string? server = "localhost";
// string? port = "5001";
// string? database = "devfreela";
// string? user = "dev";
// string? password = "yma2578k";

string connectionString = $"Host={server};" +
                          $"Port={port};" +
                          $"Pooling=true;" +
                          $"Database={database};" +
                          $"User Id={user};" +
                          $"Password={password};";


// Add services to the container.
builder.Services.AddDbContext<DevFreelaDbContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();