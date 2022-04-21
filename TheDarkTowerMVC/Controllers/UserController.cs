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
            HttpContext.Session.SetString("userid", "");
            HttpContext.Session.SetString("userrole", "");
            return View();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            HttpContext.Session.SetString("userid", "");
            HttpContext.Session.SetString("userrole", "");
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

        [HttpGet]
        [Route("account")]
        public IActionResult Account()
        {
            return View();
        }

        [HttpGet]
        [Route("friendlist")]
        public IActionResult FriendList()
        {
            var id = HttpContext.Session.GetString("userid");
            var friendList = _userService.GetFriendList(id);
            if (friendList == null)
            {
                _logger.LogError("Didn't find any friends!");
                return NotFound();
            }
            else
            {
                //ViewData["FriendList"] = friendList;
                ViewData.Add("FriendList", friendList);
                if (friendList[0] != null)
                    _logger.LogInformation("UserController; SendMessage; Returned succesfully from UserService/GetFriendList! Number of friends found: " + friendList.Count);
                //Console.WriteLine(friendList[0]);
                else
                {
                    _logger.LogError("UserController; SendMessage; No friends found!");
                }
            }
            return View();
        }

        [HttpGet]
        [Route("sendmessage")] //as soon as this page opens
        public IActionResult SendMessage()
        {
            var id = HttpContext.Session.GetString("userid");
            _logger.LogInformation("UserController; SendMessage; Current user: " + id);
            var friendList = _userService.GetFriendList(id);
            if (friendList == null)
            {
                _logger.LogError("UserController; Haven't found any friends!");
                return NotFound();
            }
            else
            {
                //ViewData["FriendList"] = friendList;
                ViewData.Add("FriendList", friendList);
                if (friendList[0] != null)
                    _logger.LogInformation("UserController; SendMessage; Returned succesfully from UserService/GetFriendList! Number of friends found: " + friendList.Count);
                //Console.WriteLine(friendList[0]);
                else
                {
                    _logger.LogError("UserController; SendMessage; No friends found!");
                }
            }
            return View();
        }

        [HttpGet]
        [Route("inbox")]
        public IActionResult Inbox()
        {
            var id = HttpContext.Session.GetString("userid");

            if (id == null) return NotFound();
            var received = _userService.GetReceivedInbox(id);

            ViewData["ReceivedInbox"] = received;

            _logger.LogInformation("UserController; Inbox; Returned succesfully from UserService!");

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
        [Route("friendlist")]
        public async Task<IActionResult> AddFriend([FromBody] AddFriendDTO friendUsername)
        {
            if (friendUsername == null)
            {
                _logger.LogError(Error.USERCONTROLLER_ADD_FRIEND_1);
                return BadRequest();
            }

            var id = HttpContext.Session.GetString("userid");
            var user = await _userService.AddFriend(id, friendUsername.Username);
            if (user == null)
            {
                _logger.LogError(Error.USERCONTROLLER_ADD_FRIEND_2);
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("sendmessage")]
        public async Task<IActionResult> AddMessage([FromBody] AddFriendDTO friendUsername)
        {
            if (friendUsername == null)
            {
                _logger.LogError(Error.USERCONTROLLER_ADD_FRIEND_1);
                return BadRequest();
            }

            var id = HttpContext.Session.GetString("userid");
            var ids = new List<String>();
            ids.Add(friendUsername.Username);
            var user = await _userService.SendMessage(id, ids);
            if (user == null)
            {
                _logger.LogError(Error.USERCONTROLLER_ADD_FRIEND_2);
                return NotFound();
            }

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
            HttpContext.Session.SetString("userrole", res.Role.ToString());

            // return Redirect("/");

            //if (res.Role == 0)
            // return Redirect("/user/register");

            return Redirect("/");

        }


    }
}
