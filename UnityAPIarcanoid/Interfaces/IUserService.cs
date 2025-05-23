using Microsoft.AspNetCore.Mvc;
using UnityAPIarcanoid.Model;
using UnityAPIarcanoid.Requests;

namespace UnityAPIarcanoid.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> Register([FromBody] UserData user);
        Task<IActionResult> Login([FromBody] UserData user);

    }
}
