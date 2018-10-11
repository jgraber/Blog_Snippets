using System;
using System.Diagnostics;
using BCrypt.Net;

namespace BCryptWorkloadCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShowCostEffect();
            ShowCostEffectVerify();
            //CalculateCost();
        }

        private static void ShowCostEffect()
        {
            var sw = new Stopwatch();
            long timeTaken;

            // warm-up
            sw.Start();
            BCrypt.Net.BCrypt.HashPassword("abc123", workFactor: 4);
            sw.Stop();
            sw.Reset();


            for (int cost = 4; cost < 20; cost++)
            {
                sw.Start();

                var hash = BCrypt.Net.BCrypt.HashPassword("abc123", workFactor: cost);

                sw.Stop();
                timeTaken = sw.ElapsedMilliseconds;

                Console.WriteLine($"{hash.Substring(0,7)} with cost {cost} need {timeTaken} ms  => {1000/timeTaken} h/s ");

                sw.Reset();
            }

            Console.WriteLine("Done...");
            Console.ReadLine();
        }

        private static void ShowCostEffectVerify()
        {
            var sw = new Stopwatch();
            long timeTaken;

            // warm-up
            sw.Start();
            BCrypt.Net.BCrypt.HashPassword("abc123", workFactor: 4);
            sw.Stop();
            sw.Reset();


            for (int cost = 4; cost < 20; cost++)
            {
                sw.Start();

                var hash = BCrypt.Net.BCrypt.HashPassword("abc123", workFactor: cost);

                sw.Stop();
                timeTaken = sw.ElapsedMilliseconds;

                Console.WriteLine($"{hash.Substring(0, 7)} with cost {cost} need {timeTaken} ms  => {1000 / timeTaken} h/s ");

                sw.Reset();

                sw.Start();

                var valid = BCrypt.Net.BCrypt.Verify("abc123", hash);

                Console.WriteLine($"{hash.Substring(0, 7)} with cost {cost} need {timeTaken} ms  => {1000 / timeTaken} h/s to verify {valid}");

                sw.Reset();

                sw.Start();

                valid = BCrypt.Net.BCrypt.Verify("abc123g", hash);

                Console.WriteLine($"{hash.Substring(0, 7)} with cost {cost} need {timeTaken} ms  => {1000 / timeTaken} h/s to verify {valid}");

                sw.Reset();

            }

            Console.WriteLine("Done...");
            Console.ReadLine();
        }

        private static void CalculateCost()
        {
            // Source: https://github.com/BcryptNet/bcrypt.net

            var cost = 20;
            var timeTarget = 100; // Milliseconds
            long timeTaken;
            do
            {
                var sw = Stopwatch.StartNew();

                BCrypt.Net.BCrypt.HashPassword("RwiKnN>9xg3*C)1AZl.)y8f_:GCz,vt3T]PI", workFactor: cost);

                sw.Stop();
                timeTaken = sw.ElapsedMilliseconds;

                Console.WriteLine($"Cost of {cost} took {timeTaken} ms");
                cost -= 1;
            } while ((timeTaken) >= timeTarget);

            Console.WriteLine("Appropriate Cost Found: " + cost);
            Console.ReadLine();
        }
    }
}
