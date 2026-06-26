namespace StockMind.StockMind.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
