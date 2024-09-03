using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Helper;

namespace WebApp.Controllers
{
    public class SpeedController : Controller
    {
        private readonly Waste _waste = new Waste();

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
            var data = GetRandomNumbers(10);
            return View(data);
        }

        private List<int> GetRandomNumbers(int count)
        {
            Random _random = new Random();
            var randomNumbers = new List<int>(count);
            for (int i = 0; i < count; i++)
            {
                randomNumbers.Add(_random.Next());
            }

            var fib = _waste.Fibonacci(30);

            return randomNumbers;
        }
    }
}
