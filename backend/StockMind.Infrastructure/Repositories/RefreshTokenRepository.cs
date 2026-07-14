using StockMind.StockMind.Application.Interfaces;
using StockMind.StockMind.Domain.Entities;
using StockMind.StockMind.Infrastructure.Data.Context;

namespace StockMind.StockMind.Infrastructure.Repositories
{
    public class RefreshTokenRepository(StockMindContext stockMindContext): IRefreshTokenRepository
    {
        private readonly StockMindContext _stockMindContext = stockMindContext;

        public async Task SetRefreshTokenAsync(RefreshToken refreshToken)
        {
            _stockMindContext.RefreshTokens.Add(refreshToken);
            await _stockMindContext.SaveChangesAsync();
        }
    }
}
