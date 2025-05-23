using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using UnityAPIarcanoid.DB;
using UnityAPIarcanoid.Interfaces;
using UnityAPIarcanoid.Model;
using UnityAPIarcanoid.Requests;
using UnityAPIarcanoid.Service;

namespace UnityAPIarcanoid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ContextDB _context;
        public UserController(IUserService userService, ContextDB context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserData user)
        {
            var result = await _userService.Register(user);
            return result;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserData user)
        {
            var result = await _userService.Login(user);
            return result;
        }

        [HttpGet("leaderboard")]
        public async Task<IActionResult> LeaderBoard()
        {
            var result = await _userService.LeaderBoard();
            return result;
        }
    } 
}
