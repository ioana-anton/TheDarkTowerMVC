using Microsoft.AspNetCore.Mvc;

namespace TheDarkTowerMVC.Profiles
{
    public class PlayerProfile : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
