using Microsoft.IdentityModel.Tokens;
using StockMind.StockMind.Application.Dto;
using StockMind.StockMind.Domain.Entities;
using StockMind.StockMind.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace StockMind.StockMind.Infrastructure.Services
{
    public class TokenService(IConfiguration configuration): ITokenService
    {
        private readonly IConfiguration _configuration = configuration;

        public string GenerateToken(UserTokenDto userTokenDto)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userTokenDto.Id.ToString()),
                new Claim(ClaimTypes.Email, userTokenDto.Email),
                new Claim(ClaimTypes.Name, userTokenDto.Name),
                new Claim(ClaimTypes.Role, userTokenDto.Role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return Convert.ToBase64String( RandomNumberGenerator.GetBytes(64));
        }

        public async Task SetRefreshToken(string refreshToken, Guid userId)
        {
            var refreshTokenBanco = new RefreshToken
            {
                UserId = userId,
                Token = refreshToken,
                CreatedAt = DateTime.UtcNow,
                ExpireAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false,
                
            };
        }
    }
}
