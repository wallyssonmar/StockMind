using Microsoft.EntityFrameworkCore;
using StockMind.StockMind.Domain.Entities;

namespace StockMind.StockMind.Infrastructure.Data.Context
{
    public class StockMindContext : DbContext
    {
        public StockMindContext(DbContextOptions<StockMindContext> options) : base(options)
        {
                
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    }
}
