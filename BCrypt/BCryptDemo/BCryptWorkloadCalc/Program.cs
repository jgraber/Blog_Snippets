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
            //ShowCostEffectVerify();
            saltInAction();
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
            BCrypt.Net.BCrypt.HashPassword("demo", workFactor: 4);
            sw.Stop();
            sw.Reset();


            for (int cost = 4; cost < 20; cost++)
            {
                sw.Start();

                string hash = BCrypt.Net.BCrypt.HashPassword("abc123", workFactor: cost);

                sw.Stop();
                timeTaken = sw.ElapsedMilliseconds;

                Console.WriteLine($"{hash.Substring(0, 7)} with cost {cost} need {timeTaken} ms  => {1000 / timeTaken} h/s ");

                sw.Reset();

                sw.Start();

                bool valid = BCrypt.Net.BCrypt.Verify("abc123", hash);

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

        private static void saltInAction()
        {
            for (int i = 0; i < 10; i++)
            {
                //var hash = BCrypt.Net.BCrypt.HashPassword("abc123", workFactor: 13);
                //Console.WriteLine(hash);
            }

            Console.WriteLine();
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var pw =
                "yvsOkgpMd3Ao07oLSMlVYAkpzF4aRKHmirH9zZKafYn9ZImsll6h5AnUbzUVYZ2xpbRQrX6IYUnxtb1lhHXR4K8sT8o5iJk847yS";
            var hash2 = BCrypt.Net.BCrypt.HashPassword(
                pw,
                salt, true);
            Console.WriteLine(hash2);
            Console.WriteLine(BCrypt.Net.BCrypt.Verify(pw, hash2, enhancedEntropy: true));

            Console.WriteLine();
            Console.WriteLine(BCrypt.Net.BCrypt.HashPassword("yvsOkgpMd3Ao07oLSMlVYAkpzF4aRKHmirH9zZKafYn9ZImsll6h5AnUbzUVYZ2xpbRQrX6IYUnxtb1lhHXR4K8sT8o5iJk847y3", salt, true));
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
