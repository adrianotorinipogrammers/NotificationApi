namespace NotificationApi.Controllers
{
    using Infra.NotificationSystem.ServiceBase;
    using Microsoft.AspNetCore.Mvc;
    using NotificationApi.Requests;
    using NotificationApi.UserServiceExemplo;

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            _userService.CreateUser(request.Username, request.Email);

            if (_userService.HasNotifications())
            {
                return BadRequest(_userService.GetNotifications());
            }

            return Ok("User created successfully.");
        }
    }
}
