using Microsoft.AspNetCore.Mvc;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Entity;
using TheDarkTowerMVC.Models.Service;
using TheDarkTowerMVC.Utils;
using TheDarkTowerMVC.Utils.FileStrategyDP;

namespace TownHall.Controllers
{
    /// <summary>
    ///  This class represents the main controller of the application.
    /// </summary>
    [ApiController]
    [Route("/user")]
    public class UserController : Controller
    {
        UserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IMessageProducer _messagePublisher;

        /// <summary>
        /// The constructor uses both the service linked to the constructor and a logger for keeping track of data.
        /// </summary>
        /// <param name="userService">Represents the service class linked to this controller.</param>
        /// <param name="logger">Represents the logger used inside this class for outputing status updates.</param>
        public UserController(UserService userService, ILogger<UserController> logger, IMessageProducer messagePublisher)
        {
            _userService = userService;
            _logger = logger;
            //new
            _messagePublisher = messagePublisher;
        }

        /// <summary>
        /// The main HttpGet which returns the homepage of this controller.
        /// </summary>
        /// <returns>Returns the homepage view of the controller.</returns>
        [HttpGet]
        [Route("login")]
        public IActionResult Index()
        {
            //ViewBag.HideNavBar = true;
            return View();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);

            HttpContext.Session.SetString("userid", id);

            if (user == null) return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Getter for the Register view.
        /// </summary>
        /// <returns>Returns the register view of the controller.</returns>
        [HttpGet]
        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Getter for the Account View.
        /// </summary>
        /// <returns>Returns the account view of the controller.</returns>
        [HttpGet]
        [Route("account")]
        public IActionResult Account()
        {
            return View();
        }


        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }


        /// <summary>
        /// Getter for the FriendList View.
        /// </summary>
        /// <returns>Returns the friendList view of the controller, populated with the current user's friends.</returns>
        [HttpGet]
        [Route("friendlist")]
        public IActionResult FriendList()
        {
            var id = HttpContext.Session.GetString("userid");
            if (id == null || id == "") return NotFound();
            var friendList = _userService.GetFriendList(id);
            if (friendList == null)
            {
                _logger.LogError("Didn't find any friends!");
                return NotFound();
            }
            else
            {
                ViewData["FriendList"] = friendList;
                // ViewData.Add("FriendList", friendList);
                if (friendList != null)
                    if (friendList.Count > 0)
                        if (friendList[0] != null)
                            _logger.LogInformation("UserController; SendMessage; Returned succesfully from UserService/GetFriendList! Number of friends found: " + friendList.Count);
                        //Console.WriteLine(friendList[0]);
                        else
                        {
                            //  _logger.LogError("UserController; SendMessage; No friends found!");
                        }
            }
            return View();
        }

        /// <summary>
        /// Getter for the Send Message View.
        /// </summary>
        /// <returns>Returns the Send Message View of the Controller.</returns>
        [HttpGet]
        [Route("sendmessage")] //as soon as this page opens
        public IActionResult SendMessage()
        {
            var id = HttpContext.Session.GetString("userid");
            if (id == null || id == "") return NotFound();
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

        /// <summary>
        /// Getter for the Inbox View.
        /// </summary>
        /// <returns>Returns the Inbox View of the curent User, onky received messages(not sent ones).</returns>
        [HttpGet]
        [Route("inbox")]
        public IActionResult Inbox()
        {
            var id = HttpContext.Session.GetString("userid");

            if (id == null || id == "") return NotFound();
            var received = _userService.GetReceivedInbox(id);

            ViewData["ReceivedInbox"] = received;

            _logger.LogInformation("UserController; Inbox; Returned succesfully from UserService!");

            return View();
        }

        /// <summary>
        /// HttpPost method for registering a new user account.
        /// </summary>
        /// <param name="createUserDTO">Represents the data brought from the user interface.</param>
        /// <returns>Returns the confirmation that a user has been created.</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> CreateUser(RegisterFormDTO registerFormDTO)
        {
            CreateUserDTO createUserDTO = new CreateUserDTO();
            createUserDTO.Username = registerFormDTO.Username;
            createUserDTO.Password = registerFormDTO.Password;
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

            RegisterEmailDTO msg = new RegisterEmailDTO();
            msg.Name = createUserDTO.Username;
            msg.Email = createUserDTO.Username;

            _messagePublisher.SendMessage(msg);

            if (registerFormDTO.FileType.Equals("pdf"))
            {
                Console.WriteLine("Ai selectat PDF!");
                PdfFileStrategy pdfFileStrategy = new PdfFileStrategy();
                FileContext fileContext = new FileContext(pdfFileStrategy);
                String input = new string("Your new account: \n Username: " + createUserDTO.Username + "\n Password: " + createUserDTO.Password);
                fileContext.CreateFile(input);
            }

            if (registerFormDTO.FileType.Equals("txt"))
            {
                Console.WriteLine("Ai selectat TXT!");
                TxtFileStrategy txtFileStrategy = new TxtFileStrategy();
                FileContext fileContext = new FileContext(txtFileStrategy);
                String input = new string("Your new account: \n Username: " + createUserDTO.Username + "\n Password: " + createUserDTO.Password);
                fileContext.CreateFile(input);
            }



            _logger.LogInformation("UserController; User-ul cu email-ul: " + user.Username + " a fost creat cu succes!");
            return Ok(user);
        }

        /// <summary>
        /// HttpPost method for adding new friends.
        /// </summary>
        ///<param name="friendUsername">Field populated from the UI with the username of the other user.</param>
        /// <returns>Returns the confirmation that a friendRequest has been sent.</returns>
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

        /// <summary>
        /// HttpPost method for sending messages.
        /// </summary>
        ///<param name="friendUsername">Field populated from the UI with the username of the recipient.</param>
        /// <returns>Returns the confirmation that a message has been sent.</returns>
        [HttpPost]
        [Route("sendmessage")]
        public async Task<IActionResult> AddMessage([FromBody] SendMessageDTO msgData)
        {
            if (msgData == null)
            {
                _logger.LogError(Error.USERCONTROLLER_ADD_FRIEND_1);
                return BadRequest();
            }

            var id = HttpContext.Session.GetString("userid");
            var message = msgData.Message;
            var friend = msgData.Recipient;

            var user = await _userService.SendMessage(id, friend, message);
            if (user == null)
            {
                _logger.LogError(Error.USERCONTROLLER_ADD_FRIEND_2);
                return NotFound();
            }

            _logger.LogInformation("Sent message with success!");

            return Ok(user);
        }

        /// <summary>
        /// HttpPost method for login.
        /// </summary>
        ///<param name="loginUserDTO">Populated with the login data from the UI.</param>
        /// <returns>The user is redirected to the main page of the application</returns>
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


            HttpContext.Session.SetString("userid", res.Id);
            HttpContext.Session.SetString("userrole", res.Role.ToString());

            //var id = HttpContext.Session.GetString("userid");
            //ViewData["CardDecks"] = _userService.GetCardDecks(res.Id);
            //ViewData["GameCards"] = _userService.Get


            // return Redirect("/");

            //if (res.Role == 0)
            // return Redirect("/user/register");

            return Redirect("/");

        }


    }
}
