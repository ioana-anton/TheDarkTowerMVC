namespace TheDarkTowerMVC.Entity
{
    public class User
    {
        //[Key]
        public String Id { get; set; } = Guid.NewGuid().ToString();

        public String Username { get; set; }

        //[Required]
        public String Password { get; set; }

        public int Role { get; set; } = 0;

        public List<CardDeck> Decks { get; set; }
    }
}
