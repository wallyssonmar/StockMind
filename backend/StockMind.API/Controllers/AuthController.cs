using Microsoft.AspNetCore.Mvc;
using StockMind.StockMind.Application.Dto;
using StockMind.StockMind.Application.Interfaces;

using StockMind.StockMind.Domain.Entities;


namespace StockMind.StockMind.API.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class AuthController(IAuthService authservice) : ControllerBase
    {
        private readonly IAuthService _authService = authservice;
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] RegisterDto user)
        {
            try
            {
                await _authService.CreateUserAsync(user);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
