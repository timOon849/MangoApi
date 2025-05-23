using Microsoft.AspNetCore.Mvc;
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
        public UserController(IUserService userService)
        {
            _userService = userService;
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
    }
}
