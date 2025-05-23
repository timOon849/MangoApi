using Microsoft.AspNetCore.Mvc;
using UnityAPIarcanoid.Interfaces;

namespace UnityAPIarcanoid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoinsController : ControllerBase
    {
        private readonly ICoinsService _coinsService;

        public CoinsController(ICoinsService coinsService)
        {
            _coinsService = coinsService;
        }

        [HttpPost("earn/{userId}/{amount}")]
        public async Task<IActionResult> EarnCoins(int userId, int amount)
        {
            return await _coinsService.EarnCoins(userId, amount);
        }

        [HttpGet("balance/{userId}")]
        public async Task<IActionResult> GetBalance(int userId)
        {
            return await _coinsService.GetBalance(userId);
        }
    }
}
