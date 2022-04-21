namespace TheDarkTowerMVC.Entity
{
    public class Recipient
    {
        public String Id { get; set; } = Guid.NewGuid().ToString();

        public User Receiver { get; set; }

        public List<Inbox> Inbox { get; set; }
    }
}
