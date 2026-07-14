using StockMind.StockMind.Application.Dto;
using StockMind.StockMind.Application.Interfaces;
using StockMind.StockMind.Domain.Entities;
using StockMind.StockMind.Infrastructure.Repositories;

namespace StockMind.StockMind.Application.Services
{
    public class AuthService(ITokenService tokenService, AuthRepository authRepository) :IAuthService
    {
        private readonly ITokenService _tokenService = tokenService;
        private readonly AuthRepository _authRepository = authRepository;

        public async Task CreateUserAsync(RegisterDto user)
        {
            var userHash = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                Role = "User",
                BirthDate = user.BirthDate,
                CreatedAt = DateTime.UtcNow
            };
            await _authRepository.CreateUserAsync(userHash);
        }
    }
}
