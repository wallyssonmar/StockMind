using StockMind.StockMind.Application.Dto;
using StockMind.StockMind.Domain.Entities;

namespace StockMind.StockMind.Application.Interfaces
{
    public interface IAuthService
    {
        Task CreateUserAsync(RegisterDto user);
    }
}
