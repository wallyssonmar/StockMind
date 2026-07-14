using StockMind.StockMind.Application.Dto;

namespace StockMind.StockMind.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserTokenDto userTokenDto);
        string GenerateRefreshToken();
        Task SetRefreshToken(string refreshToken, Guid userId);
    }
}
