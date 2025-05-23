using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnityAPIarcanoid.DB;
using UnityAPIarcanoid.Interfaces;
using UnityAPIarcanoid.Model;

namespace UnityAPIarcanoid.Service
{
    public class BallSkinService : IBallSkinService
    {
        private ContextDB _context;
        public BallSkinService(ContextDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> BuySkin(int userId, int SkinId)
        {
            var user = await _context.User.Where(x => x.Id == userId).FirstOrDefaultAsync();
            var ballSkin = await _context.BallSkin.Where(x => x.Id == SkinId).FirstOrDefaultAsync();
            if (ballSkin == null)
            {
                return new BadRequestObjectResult(new
                {
                    Error = "Неверный идентификатор скина"
                });
            }
            if (user.Coins < ballSkin.Price)
            {
                return new BadRequestObjectResult(new
                {
                    Error = "Недостаточно средств",
                    ErrorCode = "INSUFFICIENT_FUNDS",
                    Required = ballSkin.Price,
                    Available = user.Coins
                });
            }
            BuySkins bs = new BuySkins()
            {
                UserId = userId,
                BallSkinId = SkinId
            };
            user.Coins -= ballSkin.Price;
            await _context.AddAsync(bs);
            await _context.SaveChangesAsync();
            return new OkObjectResult($"Пользователь {user.Username} купил скин {ballSkin.Name}");
        }

        public async Task<IActionResult> GetAllSkins()
        {
            var skins = await _context.BallSkin.ToListAsync();
            return new OkObjectResult(new { Skins = skins });
        }

        public async Task<IActionResult> GetAvailableSkins(int userId)
        {
            var availables = await _context.BuySkins.Where(x => x.UserId == userId).ToListAsync();
            return new OkObjectResult(new { Skins = availables });
        }

        public async Task<IActionResult> GetCurrentSkin(int userId)
        {
            var skin = await _context.CurrentSkin.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            return new OkObjectResult(new { Skin = skin });
        }

        public async Task<IActionResult> SetCurrentSkin(int userId, int SkinId)
        {
            var skin = await _context.CurrentSkin.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            skin.BallSkinId = SkinId;
            await _context.SaveChangesAsync();
            return new OkObjectResult(new { Skin = skin });
        }
    }
}
