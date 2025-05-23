using Microsoft.AspNetCore.Mvc;
using UnityAPIarcanoid.Interfaces;

namespace UnityAPIarcanoid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BallSkinsController : ControllerBase
    {
        private readonly IBallSkinService _ballSkinService;

        public BallSkinsController(IBallSkinService ballSkinService)
        {
            _ballSkinService = ballSkinService;
        }
        [HttpGet("GetAllSkins")]
        public async Task<IActionResult> GetAllSkins()
        {
            return await _ballSkinService.GetAllSkins();
        }
        [HttpPost("BuySkin/{UserId}/{SkinId}")]
        public async Task<IActionResult> BuySkin(int UserId, int SkinId)
        {
            return await _ballSkinService.BuySkin(UserId, SkinId);
        }
        [HttpGet("GetAvailableSkins/{userId}")]
        public async Task<IActionResult> GetAvailableSkins(int userId)
        {
            return await _ballSkinService.GetAvailableSkins(userId);
        }
        [HttpGet("GetCurrentSkin/{userId}")]
        public async Task<IActionResult> GetCurrentSkin(int userId)
        {
            return await _ballSkinService.GetCurrentSkin(userId);
        }
        [HttpPost("SetCurrentSkin/{userId}/{SkinId}")]
        public async Task<IActionResult> SetCurrentSkin(int userId, int SkinId)
        { 
            return await _ballSkinService.SetCurrentSkin(userId, SkinId);
        }
    }
}
