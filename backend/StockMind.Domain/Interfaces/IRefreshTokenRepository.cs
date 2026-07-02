using StockMind.StockMind.Domain.Entities;

namespace StockMind.StockMind.Domain.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task SetRefreshTokenAsync(RefreshToken refreshToken);
    }
}
