namespace TheDarkTowerMVC.Entity
{
    public class EntityFactory
    {

        public static CardDeck createDefaultCardDeck()
        {
            var deck = new CardDeck();

            deck.CreatedDateTime = DateTime.Now;

            return deck;
        }
    }
}
