using StockMind.StockMind.Application.Dto;

namespace StockMind.StockMind.Domain.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserTokenDto userTokenDto);
        string GenerateRefreshToken();
    }
}
