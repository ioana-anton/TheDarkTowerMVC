using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheDarkTowerMVC.DTO;
using TheDarkTowerMVC.Entity;
using TheDarkTowerMVC.Models.Repository;

namespace TheDarkTowerMVC.Models.Service
{
    public class PlayerService
    {
        private readonly PlayerRepo _playerRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<PlayerService> _logger;

        public PlayerService(PlayerRepo playerRepo, IMapper mapper, ILogger<PlayerService> logger)
        {
            _playerRepo = playerRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GameCardDTO> GetCardById(String id)
        {
            if (id == null) return null;
            if (id == "") return null;
            var card = await _playerRepo.GetCardById(id);
            return _mapper.Map<GameCardDTO>(card);
        }

        public async Task<UserDTO> GetUserById(String id)
        {
            if (id == null) return null;
            var user = await _playerRepo.GetUserById(id);
            return _mapper.Map<UserDTO>(user);
        }


        public List<GameCardDTO> GetGameCards()
        {
            var cards = _playerRepo.GetGameCards();
            if (cards.Count == 0)
            {
                _logger.LogError("There are no game cards!");
            }

            return _mapper.Map<List<GameCardDTO>>(cards);
        }

        public async Task<CreatedDeckDTO> CreateDeck(String userId, SDeleteCardsDTO cards)
        {
            var user = await _playerRepo.GetUserById(userId);
            var name = cards.Cards.Last();
            cards.Cards.Remove(cards.Cards.Last());

            var gameCardsToAdd = new List<GameCard>();
            foreach (var card in cards.Cards)
            {
                var newCard = await _playerRepo.GetCardByName(card);
                gameCardsToAdd.Add(newCard);
                Console.Write("GameMasterService; DeleteCards; Added to delete: "
                    + newCard.Id);
            }
            var deck = await _playerRepo.CreateCardDeck(gameCardsToAdd, name, user);

            return _mapper.Map<CreatedDeckDTO>(deck);
        }
    }
}
