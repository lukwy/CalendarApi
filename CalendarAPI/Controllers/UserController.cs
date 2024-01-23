using CalendarAPI.Models;
using CalendarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalendarAPI.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userName}")]
        public async Task<bool> CheckUserExists(string userName)
        {
            return await _userService.CheckUserExistsAsync(userName);
        }

        [HttpGet("{userName}/{password}")]
        public async Task<int> LogIn(string userName, string password)
        {
            return await _userService.LogInAsync(userName, password);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(User user)
        {
            await _userService.InsertAsync(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _userService.DeleteAsync(id);
        }
    }
}
