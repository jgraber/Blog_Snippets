using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SpeedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmptyPage()
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

        public IActionResult Data()
        {
            var data = GetRandomNumbersAsync(10);
            return View(data);
        }

        private static List<int> GetRandomNumbersAsync(int count)
        {
            Random _random = new Random();
            var randomNumbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(100);
                randomNumbers.Add(_random.Next());
            }

            return randomNumbers;
        }
    }
}
