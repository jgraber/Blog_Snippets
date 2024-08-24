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

        public IActionResult Slow()
        {
            Thread.Sleep(50);
            return View();
        }

        public async Task<IActionResult> AsyncSlow()
        {
            await Task.Delay(50);
            return View();
        }
    }
}
