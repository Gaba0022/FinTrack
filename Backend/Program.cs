using Backend.Application.Mappings;
using Backend.Application.Services;
using Backend.Application.Services.Jwt;
using Backend.Infrastructure.Persistence;
using Backend.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Conexão com o banco de dados MySQL
var _connectionSring = builder.Configuration.GetConnectionString("DefaultConnection");


// Add services to the container.
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<CryptoRepository>();
builder.Services.AddScoped<CryptoService>();

builder.Services.AddScoped<PriceHistoryRepository>();
builder.Services.AddScoped<PriceHistoryService>();

builder.Services.AddScoped<PriceAlertRepository>();
builder.Services.AddScoped<PriceAlertService>();

builder.Services.AddScoped<IJwtService>(_ => new JwtService(builder.Configuration));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(_connectionSring, ServerVersion.AutoDetect(_connectionSring)));


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
