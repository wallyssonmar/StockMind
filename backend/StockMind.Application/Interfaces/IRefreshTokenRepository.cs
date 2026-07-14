using StockMind.StockMind.Domain.Entities;

namespace StockMind.StockMind.Application.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task SetRefreshTokenAsync(RefreshToken refreshToken);
    }
}
