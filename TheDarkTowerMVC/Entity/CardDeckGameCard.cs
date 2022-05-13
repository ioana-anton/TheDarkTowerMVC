namespace TheDarkTowerMVC.Entity
{
    public class CardDeckGameCard
    {
        public String GameCardId { get; set; }
        public GameCard GameCard { get; set; }
        public String CardDeckId { get; set; }
        public CardDeck CardDeck { get; set; }
    }
}
