using Microsoft.AspNetCore.Mvc;
using TheDarkTowerMVC.Data;
using TheDarkTowerMVC.Entity;
using System.Data.Entity;
using TheDarkTowerMVC.DTO;

namespace TheDarkTowerMVC.Models.Repository
{
    public class PlayerRepo
    {
        private readonly DatabaseContext databaseContext;

        public PlayerRepo(DatabaseContext dbContext)
        {
            databaseContext = dbContext;
        }

        public async Task<User> GetUserById(String id)
        {
            var user = databaseContext.Users.Where(y => y.Id == id).Include(x => x.Decks).ToList().First();
            return user;
        }

        public List<CardDeck> GetCardDecks(String owner)
        {

            var decks = databaseContext.CardDecks.Where(y => y.UserId == owner || y.byAdmin).ToList();

            return decks;
        }

        public async Task<GameCard> GetCardByName(String name)
        {


            var card = databaseContext.GameCard.Where(x => x.Name.Equals(name)).Include(y => y.CardDeck).ToList().First();

            return card;
        }


        public async Task<GameCard> GetCardById(String id)
        {


            var card = databaseContext.GameCard.Where(x => x.Id.Equals(id)).Include(y => y.CardDeck).ToList().First();

            return card;
        }


        public List<GameCard> GetGameCards()
        {
            return databaseContext.GameCard.ToList();
        }

        public async Task<CardDeck> CreateCardDeck(List<GameCard> cards, String name, User user)
        {
            // var user = await GetUserById(userDTO.Id);
            var cardDeck = EntityFactory.createDefaultCardDeck();
            cardDeck.Name = name;
            cardDeck.Cards = cards;
            cardDeck.User = user;
            cardDeck.UserId = user.Id;
            cardDeck.byAdmin = false;

            databaseContext.CardDecks.Add(cardDeck);
            await databaseContext.SaveChangesAsync();

            return cardDeck;
        }

    }
}
