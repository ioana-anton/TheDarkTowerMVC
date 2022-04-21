﻿using Microsoft.AspNetCore.Mvc;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Models.Service;
using TheDarkTowerMVC.Utils;

namespace TheDarkTowerMVC.Controllers
{
    [ApiController]
    [Route("/gm")]
    public class GameMasterController : Controller
    {
        private readonly ILogger<GameMasterController> _logger;
        private GameMasterService _gmService;

        public GameMasterController(GameMasterService gmService, ILogger<GameMasterController> logger)
        {
            _logger = logger;
            _gmService = gmService;
        }

        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("createcard")]
        public IActionResult CreateCard()
        {
            var cards = _gmService.GetGameCards();
            if (cards.Count == 0)
            {
                _logger.LogError("GameMasterController; CreateCard; 0 cards returned from GameMasterService");
            }
            ViewData["GameCards"] = cards;
            return View();
        }

        [HttpPost]
        [Route("createcard")]
        public async Task<IActionResult> CreateCard([FromBody] AddCardDTO cardDTO)
        {
            if (cardDTO.Name == null)
            {
                _logger.LogError(Error.GAMEMASTERCONTROLLER_ADD_CARD_INPUT);
                return BadRequest();
            }
            _logger.LogInformation("GameMasterController; CreateCard; Before query;");
            var card = await _gmService.CreateCard(cardDTO);
            if (card == null)
            {
                _logger.LogError(Error.GAMEMASTERCONTROLLER_ADD_CARD_SERVICE);
                return NotFound();
            }

            _logger.LogInformation("GameMaster; CreateCard; Created Card with: id= " + card.Id + " & name = " + card.Name);
            ViewData["GameCards"] = _gmService.GetGameCards();
            return Ok(card);
        }

        [HttpDelete]
        [Route("deletecards")]
        public async Task<IActionResult> DeleteCards([FromBody] SDeleteCardsDTO selectedCards)
        {
            if (selectedCards == null)
            {
                _logger.LogError("GameMasterController; DeleteCards; No selected cards to delete.");
                return BadRequest();
            }

            _logger.LogInformation("GameMaster; DeleteCards; Number of cards deleted: " + selectedCards.Cards.Count);

            var cardsToDelete = new List<DeleteCardDTO>();
            foreach (var card in selectedCards.Cards)
            {
                var deleteCard = new DeleteCardDTO();
                deleteCard.Name = card;
                cardsToDelete.Add(deleteCard);
            }

            await _gmService.DeleteCards(cardsToDelete);

            ViewData["GameCards"] = _gmService.GetGameCards();


            return Ok();
        }


    }
}
