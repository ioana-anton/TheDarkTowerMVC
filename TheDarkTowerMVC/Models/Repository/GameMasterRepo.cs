using Microsoft.AspNetCore.Mvc;
using TheDarkTowerMVC.Data;
using TheDarkTowerMVC.Entity;
using System.Data.Entity;

namespace TheDarkTowerMVC.Models.Repository
{
    public class GameMasterRepo
    {
        private readonly DatabaseContext databaseContext;

        public GameMasterRepo(DatabaseContext dbContext)
        {
            databaseContext = dbContext;
        }

        public async Task<GameCard> GetCardById(String id)
        {


            var card = databaseContext.GameCard.Where(x => x.Id.Equals(id)).Include(y => y.CardDeck).ToList().First();

            return card;
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

        public async Task InsertNewCard(GameCard card)
        {
            if (card == null) throw new ArgumentNullException("card");
            else
            {
                databaseContext.GameCard.Add(card);
                Console.WriteLine("GameMasterRepo; InsertNewCard; Inserted: " + card.Name);
            }
            await databaseContext.SaveChangesAsync();
        }

        public List<GameCard> GetGameCards()
        {
            return databaseContext.GameCard.ToList();
        }

        public async Task DeleteCards(List<GameCard> cards)
        {
            foreach (GameCard card in cards)
            {
                databaseContext.GameCard.Remove(card);
                var decks = databaseContext.CardDecks.Where(u => u.Cards.Contains(card)).ToList();
                foreach (CardDeck deck in decks)
                    databaseContext.CardDecks.Remove(deck);

                await databaseContext.SaveChangesAsync();
            }
        }

    }
}
