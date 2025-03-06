using EF_Assignment_2.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Scoped: New instance per request (Best practice)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(connectionString), ServiceLifetime.Singleton);

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(connectionString), ServiceLifetime.Transient);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
