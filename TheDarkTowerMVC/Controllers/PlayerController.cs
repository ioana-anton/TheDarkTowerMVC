﻿using Microsoft.AspNetCore.Mvc;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Models.Service;

namespace TheDarkTowerMVC.Controllers
{
    [ApiController]
    [Route("/player")]
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> _logger;
        private PlayerService _playerService;

        public PlayerController(PlayerService playerService, ILogger<PlayerController> logger)
        {
            _logger = logger;
            _playerService = playerService;
        }

        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            ViewData["GameCards"] = _playerService.GetGameCards();
            return View();
        }

        [HttpGet]
        [Route("decks")]
        public IActionResult Decks()
        {
            ViewData["GameCards"] = _playerService.GetGameCards();
            return View();
        }

        [HttpGet]
        [Route("adddeck")]
        public IActionResult AddDeck()
        {
            ViewData["GameCards"] = _playerService.GetGameCards();
            return View();
        }

        [HttpPost]
        [Route("adddeck")]
        public async Task<IActionResult> AddDeck([FromBody] SDeleteCardsDTO selectedCards)
        {
            if (selectedCards == null)
            {
                _logger.LogError("PlayerController; AddDeck; No data was selected.");
                return BadRequest();
            }
            _logger.LogInformation("PlayerController; AddDeck; Preparing to create: " + selectedCards.Cards.Last());

            var id = HttpContext.Session.GetString("userid");
            await _playerService.CreateDeck(id, selectedCards);

            //ViewData["GameCards"] = _playerService.GetGameCards();

            return Ok();
        }


    }
}