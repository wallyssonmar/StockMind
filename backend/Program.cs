using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StockMind.StockMind.Infrastructure.Data.Context;

using System.Text;
using StockMind.StockMind.Infrastructure.Repositories;
using StockMind.StockMind.Application.Interfaces;
using StockMind.StockMind.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using StockMind.StockMind.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Injeção de Dependência Services.
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();

//Injeção de Dependência Repositories.
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<AuthRepository, AuthRepository>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "StockMind API",
        Version = "v1",
        Description = "API para gerenciamento inteligente de estoque."
    });

});



builder.Services.AddDbContext<StockMindContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI( options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "StockMind API v1");
    });
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
