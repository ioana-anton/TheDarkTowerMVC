using Microsoft.AspNetCore.Mvc;

namespace TheDarkTowerMVC.Controllers
{
    [ApiController]
    [Route("/player")]
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("decks")]
        public IActionResult Decks()
        {
            return View();
        }

        [HttpGet]
        [Route("adddeck")]
        public IActionResult AddDeck()
        {

            return View();
        }


    }
}
