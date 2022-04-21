using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Entity;
using TheDarkTowerMVC.Models.Repository;
using TheDarkTowerMVC.Utils;

namespace TheDarkTowerMVC.Models.Service
{
    public class GameMasterService
    {
        private readonly GameMasterRepo _gmRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<GameMasterService> _logger;

        public GameMasterService(GameMasterRepo userRepo, IMapper mapper, ILogger<GameMasterService> logger)
        {
            _gmRepo = userRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GameCardDTO> GetCardById(String id)
        {
            if (id == null) return null;
            if (id == "") return null;
            var card = await _gmRepo.GetCardById(id);
            return _mapper.Map<GameCardDTO>(card);
        }

        public List<CardDeckDTO> GetCardDecks(String userId)
        {
            var decks = _gmRepo.GetCardDecks(userId);
            if (decks.Count == 0)
            {
                _logger.LogError("There are no decks!");
                return null;
            }
            return _mapper.Map<List<CardDeckDTO>>(decks);
        }

        public async Task<GameCardDTO> CreateCard(AddCardDTO addCard)
        {
            // EntityFactory cardFactory = new EntityFactory();

            CardBuilder cardBuilder = new CardBuilder();

            var card = cardBuilder.setPower(addCard.Power).setName(addCard.Name).setHealth(addCard.Health).setDescription(addCard.Description).build();
            try
            {
                await _gmRepo.InsertNewCard(card);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex.Message);
            }

            return await GetCardById(card.Id);
        }

        public List<GameCardDTO> GetGameCards()
        {
            var cards = _gmRepo.GetGameCards();
            if (cards.Count == 0)
            {
                _logger.LogError("There are no game cards!");
            }

            return _mapper.Map<List<GameCardDTO>>(cards);
        }

        public async Task<List<GameCardDTO>> DeleteCards(List<DeleteCardDTO> cards)
        {
            var gameCardsToDelete = new List<GameCard>();
            foreach (var card in cards)
            {
                var newCard = await _gmRepo.GetCardByName(card.Name);
                gameCardsToDelete.Add(newCard);
                Console.Write("GameMasterService; DeleteCards; Added to delete: "
                    + newCard.Id);
            }
            if (gameCardsToDelete.Count != 0)
                await _gmRepo.DeleteCards(gameCardsToDelete);

            var rez = _gmRepo.GetGameCards();
            return _mapper.Map<List<GameCardDTO>>(rez);
        }
    }
}
