using Microsoft.AspNetCore.Mvc;
using SleepTrackerApi.Models;
using SleepTrackerApi.Services;
using System.Threading.Tasks;

namespace SleepTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var user = await _userService.RegisterUserAsync(request.Login, request.Password);
            return Ok(user);
        }
    }

   public class UserRegistrationRequest
{
    public string Login { get; set; }
    public string Password { get; set; }

    // Конструктор с обязательными параметрами
    public UserRegistrationRequest(string login, string password)
    {
        Login = login;
        Password = password;
    }
}
}
