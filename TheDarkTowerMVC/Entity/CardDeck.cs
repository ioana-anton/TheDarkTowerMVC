namespace TheDarkTowerMVC.Entity
{
    public class CardDeck
    {
        public String Id { get; set; } = Guid.NewGuid().ToString();

        //public int Id { get; set; }
        public String Name { get; set; }
        public String UserId { get; set; }
        public User User { get; set; }
        public Boolean byAdmin { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual List<CardDeckGameCard> CardDeckGameCards { get; set; }

    }
}
