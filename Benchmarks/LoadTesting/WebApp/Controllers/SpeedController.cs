using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SpeedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Empty()
        {
            return View();
        }
    }
}
