using Microsoft.AspNetCore.Mvc;

namespace UnityAPIarcanoid.Interfaces
{
    public interface ICoinsService
    {
        Task<IActionResult> GetBalance(int userId);
        Task<IActionResult> EarnCoins(int userId, [FromBody] int amount);

    }
}
