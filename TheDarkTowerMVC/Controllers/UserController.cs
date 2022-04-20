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
        private readonly ILogger<UserController> _logger;

        public UserController(UserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
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
        [Route("login")]

        public async Task<IActionResult> LoginUser(LoginUserDTO loginUserDTO)
        {
            var res = await _userService.LoginUser(loginUserDTO);

            //if ((res.Email!=null)) return BadRequest();
            //  Console.WriteLine(res.Email);
            _logger.LogInformation("UserController: Revenire cu succes din userService! ");

            if (res == null) return NotFound();

            HttpContext.Session.SetString("userid", res.Id);

            return Redirect("/");
        }
    }
}
