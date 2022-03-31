namespace TheDarkTowerMVC.Entity
{
    public class User
    {
        //[Key]
        public String Id { get; set; } = Guid.NewGuid().ToString();

        public String Name { get; set; }

        //[Required]
        public String Email { get; set; }

        //[Required]
        public String Password { get; set; }
    }
}
