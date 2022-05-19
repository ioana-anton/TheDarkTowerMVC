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

            var decks = databaseContext.CardDecks.Where(y => y.UserId == owner || y.byAdmin)
                .Include("CardDeckGameCards.GameCard").ToList();
            // .ThenInclude(x => x.GameCard);
            // .ToList();

            return decks;
        }

        public async Task<GameCard> GetCardByName(String name)
        {


            var card = databaseContext.GameCard.Where(x => x.Name.Equals(name)).Include("CardDeckGameCards.CardDeck").ToList().First();

            return card;
        }


        public async Task<GameCard> GetCardById(String id)
        {


            var card = databaseContext.GameCard.Where(x => x.Id.Equals(id)).Include("CardDeckGameCards.CardDeck").ToList().First();

            return card;
        }


        public List<GameCard> GetGameCards()
        {
            return databaseContext.GameCard.ToList();
        }

        public List<GameCard> GetCardsFromDeck(String deckId)
        {
            if (deckId != null)
            {
                var deck = databaseContext.CardDecks.Where(x => x.Id.Equals(deckId)).FirstOrDefault();
                var link = databaseContext.CardDeckGameCard.Where(y => y.CardDeckId.Equals(deckId)).ToList();
                var cards = new List<GameCard>();
                foreach (var cardDeckGameCard in link)
                {
                    //var card = databaseContext.GameCard.Where(y => y.Id.Equals(cardid)).FirstOrDefault();
                    //cards.Add(card);
                    cards.Add(cardDeckGameCard.GameCard);
                }
                Console.WriteLine("Am gasit deck: " + deck.Name + " si: " + cards.Count());
                Console.WriteLine("PlayerRepo/GetCardsFromDeck: " + deck.CardDeckGameCards.Count());
                if (cards != null) return cards;
            }

            //List<GameCard> cards = new List<GameCard>();
            //if (deck != null)
            //{

            //        var list = deck.CardDeckGameCards.Where(u => u.CardDeckId.Equals(deckId));
            //        foreach (CardDeckGameCard? card in list)
            //        {
            //            cards.Add(card.GameCard);
            //        };

            //        return cards;
            //    }
            //    else
            //    {
            //        Console.WriteLine("PLAYERREPO: DECK ESTE NULL!");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("PLAYERREPO: DECKID ESTE NULL!");
            //}

            return null;
        }

        public async Task<CardDeck> CreateCardDeck(List<GameCard> cards, String name, User user)
        {
            // var user = await GetUserById(userDTO.Id);
            var cardDeck = EntityFactory.createDefaultCardDeck();
            cardDeck.Name = name;
            List<CardDeckGameCard> items = new List<CardDeckGameCard>();
            foreach (var card in cards)
            {
                //var item = databaseContext.CardDeckGameCard.Where(u => u.GameCard.Equals(card)).FirstOrDefault();
                //if (item != null)
                //{
                //    items.Add(item);
                //    Console.WriteLine("Am inserat: " + item.GameCardId);
                //}

                var item = new CardDeckGameCard();
                item.CardDeck = cardDeck;
                item.CardDeckId = cardDeck.Id;
                item.GameCard = card;
                item.GameCardId = card.Id;
                items.Add(item);
                Console.WriteLine("Am inserat: " + item.GameCardId);

            }
            cardDeck.CardDeckGameCards = items;
            cardDeck.User = user;
            cardDeck.UserId = user.Id;
            cardDeck.byAdmin = false;

            databaseContext.CardDecks.Add(cardDeck);
            await databaseContext.SaveChangesAsync();

            return cardDeck;
        }

    }
}
