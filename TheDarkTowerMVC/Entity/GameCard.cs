using System.Text.Json.Serialization;

namespace TheDarkTowerMVC.Entity
{
    public class GameCard
    {
        public String Id { get; set; } = Guid.NewGuid().ToString();

        public String Name { get; set; }
        public int Power { get; set; }
        public int Health { get; set; }
        public String Description { get; set; }

        public String ImageLink { get; set; }

        public List<CardDeckGameCard> CardDeckGameCards { get; set; }
    }
}
