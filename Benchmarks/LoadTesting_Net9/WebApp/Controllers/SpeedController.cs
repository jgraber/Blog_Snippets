using System;
using System.IO.Pipelines;
using System.Runtime.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApp.Helper;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SpeedController : Controller
    {
        private readonly Waste _waste = new Waste();
        private readonly Logic _logic = new Logic();
        private readonly HttpClient _client = new HttpClient();
        private static List<byte[]> keep = new List<byte[]>();

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

        public async Task<IActionResult> Service()
        {
            var result = await _client.GetStringAsync("https://localhost:7256/weatherforecast");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var data = JsonSerializer.Deserialize<IEnumerable<Forecast>>(result, options);
            return View(data);
        }

        public IActionResult Leak()
        {
            byte[] data = new byte[1024 * 1024 * 100];
            Array.Clear(data, 0, data.Length);
            keep.Add(data);

            return View();
        }

        public IActionResult LeakLib()
        {
            byte[] data = new byte[1024 * 1024 * 100];
            Array.Clear(data, 0, data.Length);
            var valid = _waste.Validate(data);

            return View();
        }

        public IActionResult DownTheRabbitHole()
        {
            Thread.Sleep(200);
            
            var output = _logic.A(2);
            Thread.Sleep(20);
            return View(output);
        }

        private List<int> GetRandomNumbers(int count)
        {
            Random _random = new Random();
            var randomNumbers = new List<int>(count);
            for (int i = 0; i < count; i++)
            {
                randomNumbers.Add(_random.Next());
            }

            //var fib = _waste.Fibonacci(35);
            //var prime = _waste.FindPrimeNumber(10000);
            //Log.Information("Found {prime}", prime);
            var end = _waste.Waiting(500);
            Log.Information("Waited until {end}", end);

            return randomNumbers;
        }
    }
}
