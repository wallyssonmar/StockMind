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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .IsRequired();

        }
    }
}
