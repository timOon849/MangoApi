using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnityAPIarcanoid.DB;
using UnityAPIarcanoid.Interfaces;
using UnityAPIarcanoid.Model;

namespace UnityAPIarcanoid.Service
{
    public class CoinsService : ICoinsService
    {
        private readonly ContextDB _context;
        private readonly IConfiguration _configuration;
        public CoinsService(ContextDB context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async  Task<IActionResult> EarnCoins(int userId, [FromBody] int amount)
        {
            var user = await _context.User.FindAsync(userId);
            if (user == null)
            {
                return new NotFoundObjectResult("Пользователь не найден");
            }

            user.Coins += amount;
            await _context.SaveChangesAsync();

            return new OkObjectResult(new { Coins = user.Coins });
        }

        public async Task<IActionResult> GetBalance(int userId)
        {
            var user = await _context.User.FindAsync(userId);
            if (user == null)
            {
                return new NotFoundObjectResult("Пользователь не найден");
            }

            return new OkObjectResult(new { Coins = user.Coins });
        }
    }
}
