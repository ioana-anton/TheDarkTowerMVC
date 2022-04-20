using TheDarkTowerMVC.Entity;

namespace TheDarkTowerMVC.Utils
{
    public class CardBuilder
    {
        GameCard card;

        public CardBuilder()
        {
            card = new GameCard();
        }

        public CardBuilder setName(String name)
        {
            card.Name = name;
            return this;
        }

        public CardBuilder setPower(int power)
        {
            card.Power = power;
            return this;
        }

        public CardBuilder setHealth(int health)
        {
            card.Health = health;
            return this;
        }

        public CardBuilder setDescription(String description)
        {
            card.Description = description;
            return this;
        }

        public CardBuilder fromCard(GameCard card)
        {
            var cardClone = new GameCard();
            cardClone.Name = card.Name;
            cardClone.Power = card.Power;
            cardClone.Health = card.Health;
            cardClone.Description = card.Description;

            this.card = cardClone;
            return this;
        }

        public GameCard build()
        {
            return card;
        }
    }
}
