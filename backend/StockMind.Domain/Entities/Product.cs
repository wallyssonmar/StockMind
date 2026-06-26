namespace StockMind.StockMind.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null;
        public required string Name { get; set; } 
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Location { get; set; }
        public int Quantity { get; set; }
    }
}
