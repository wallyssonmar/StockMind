using StockMind.StockMind.Domain.Entities;
using StockMind.StockMind.Infrastructure.Data.Context;

namespace StockMind.StockMind.Infrastructure.Repositories
{
    public class AuthRepository(StockMindContext stockMindContext)
    {
        private readonly StockMindContext _stockMindContext = stockMindContext;
        public async Task CreateUserAsync(User user)
        {
            _stockMindContext.Users.AddAsync(user);
            await _stockMindContext.SaveChangesAsync();
        }
    }
}
