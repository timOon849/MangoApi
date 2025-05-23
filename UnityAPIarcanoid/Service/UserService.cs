using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnityAPIarcanoid.DB;
using UnityAPIarcanoid.Interfaces;
using UnityAPIarcanoid.Model;
using UnityAPIarcanoid.Requests;

namespace UnityAPIarcanoid.Service
{
    public class UserService : IUserService
    {
        private readonly ContextDB _context;
        private readonly IConfiguration _configuration;

        public UserService(ContextDB context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<IActionResult> Login([FromBody] UserData user)
        {
            var existingUser = await _context.User.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (existingUser == null || existingUser.Password != user.Password)
            {
                return new UnauthorizedObjectResult("Неверный логин или пароль");
            }

            var token = GenerateJwtToken(existingUser);
            return new OkObjectResult(new { Token = token });
        }

        public async Task<IActionResult> Register([FromBody] UserData user)
        {
            if (await _context.User.AnyAsync(u => u.Username == user.Username))
                return new BadRequestObjectResult("Пользователь уже существует");
            User _user = new User
            {
                Username = user.Username,
                Password = user.Password,
                Coins = 100
            };

            await _context.User.AddAsync(_user);
            await _context.SaveChangesAsync();
            BuySkins bs = new BuySkins();
            bs.BallSkinId = 1;
            bs.UserId = _user.Id;
            await _context.BuySkins.AddAsync(bs);
            await _context.SaveChangesAsync();
            CurrentSkin cs = new CurrentSkin();
            cs.UserId = _user.Id;
            cs.BallSkinId = 1;
            await _context.CurrentSkin.AddAsync(cs);
            await _context.SaveChangesAsync();
            var token = GenerateJwtToken(_user);
            return new OkObjectResult(new { Token = token });
        }

        private string GenerateJwtToken(User user)
        {
            var jwtKey = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new InvalidOperationException("JWT Key is not configured.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}