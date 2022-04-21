namespace TheDarkTowerMVC.Entity
{
    public class Inbox
    {
        public String Id { get; set; } = Guid.NewGuid().ToString();

        public String Message { get; set; }

        public User Sender { get; set; }

        public List<Recipient> Recipients { get; set; } //single or multiple


    }
}
