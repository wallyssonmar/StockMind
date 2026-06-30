namespace StockMind.StockMind.Application.Dto
{
    public class UserTokenDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
    }
}
