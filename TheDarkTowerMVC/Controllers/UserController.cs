using Microsoft.AspNetCore.Mvc;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Entity;
using TheDarkTowerMVC.Models.Service;
using TheDarkTowerMVC.Utils;

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

        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUserDTO)
        {
            if (createUserDTO == null)
            {
                // _logger.LogError(Error.USERCONTROLLER_CREATE_USER);
                return BadRequest();
            }
            var user = await _userService.CreateUser(createUserDTO);

            if (user == null)
            {
                _logger.LogError(Error.USERCONTROLLER_CREATE_USER);
                return NotFound();
            }

            _logger.LogInformation("UserController; User-ul cu email-ul: " + user.Username + " a fost creat cu succes!");
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> LoginUser(LoginUserDTO loginUserDTO)
        {
            var res = await _userService.LoginUser(loginUserDTO);

            if (res == null)
            {
                _logger.LogError(Error.USERCONTROLLER_USER_SELECT);
                return NotFound();
            }
            else
            {
                _logger.LogInformation("UserController: Revenire cu succes din userService! ");
                _logger.LogInformation("UserController: Rol user: " + res.Role);
            }

            //CardDeck cardDeck = EntityFactory.createDefaultCardDeck();

            //Console.Write("Test default deck: " + cardDeck.CreatedDateTime);

            //CardBuilder cardBuilder = new CardBuilder();

            //GameCard card = cardBuilder.setPower(100).setHealth(10).build();

            //Console.Write("Test card builder: power: " + card.Power + " health: " + card.Health);


            HttpContext.Session.SetString("userid", res.Id);

            // return Redirect("/");

            if (res.Role == 0)
                return Redirect("/user/register");

            return Redirect("/user/login");

        }


    }
}
