namespace TheDarkTowerMVC.Entity
{
    public class Friend
    {
        public String Id { get; set; } = Guid.NewGuid().ToString();

        public User User { get; set; }

    }
}
