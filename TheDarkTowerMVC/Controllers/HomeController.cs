using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheDarkTowerMVC.Models;

namespace TheDarkTowerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("userid") == null)
            {
                HttpContext.Session.SetString("userid", "");
                HttpContext.Session.SetString("userrole", "");

                return View("~/Views/User/Index.cshtml");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}