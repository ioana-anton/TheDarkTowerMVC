namespace TheDarkTowerMVC.Entity
{
    public class CardDeck
    {
        public String Id { get; set; } = Guid.NewGuid().ToString();
        public String UserId { get; set; }
        public User User { get; set; }
        public Boolean byAdmin { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public List<GameCard> Cards { get; set; }

    }
}
