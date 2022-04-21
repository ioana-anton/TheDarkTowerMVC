using Microsoft.AspNetCore.Mvc;

namespace TheDarkTowerMVC.DTO
{
    public class AddCardDTO
    {
        public String Name { get; set; }
        public int Power { get; set; }
        public int Health { get; set; }
        public String Description { get; set; }

    }
}
