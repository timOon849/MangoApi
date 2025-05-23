using Microsoft.AspNetCore.Mvc;

namespace UnityAPIarcanoid.Interfaces
{
    public interface IBallSkinService
    {
        Task<IActionResult> GetAllSkins();
        Task<IActionResult> GetAvailableSkins(int userId);
        Task<IActionResult> SetCurrentSkin(int userId, int SkinId);
        Task<IActionResult> GetCurrentSkin(int userId);
        Task<IActionResult> BuySkin(int userId, int SkinId);
    }
}
