using StockMind.StockMind.Domain.Entities;
using StockMind.StockMind.Domain.Interfaces;
using StockMind.StockMind.Infrastructure.Data.Context;

namespace StockMind.StockMind.Infrastructure.Repositories
{
    public class RefreshTokenRepository(StockMindContext stockMindContext): IRefreshTokenRepository
    {
        private readonly StockMindContext _stockMindContext = stockMindContext;

        public async Task SetRefreshTokenAsync(RefreshToken refreshToken)
        {
            await _stockMindContext.RefreshTokens.AddAsync(refreshToken);
            await _stockMindContext.SaveChangesAsync();
        }
    }
}
