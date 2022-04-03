using Microsoft.AspNetCore.Mvc;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Models.Service;

namespace TownHall.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : Controller
    {
        UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUserDTO)
        {
            if (createUserDTO == null) return BadRequest();
            var user = await _userService.CreateUser(createUserDTO);
            return Ok(user);
        }

        [HttpPost]
        [Route("/login")]

        public async Task<IActionResult> LoginUser(LoginUserDTO loginUserDTO)
        {
            // var res = await _userService.LoginUser(loginUserDTO);

            //  if (!res) return BadRequest();
            return Ok("/Home");
        }
    }
}
