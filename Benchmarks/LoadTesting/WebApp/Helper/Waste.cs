namespace WebApp.Helper;

public class Waste
{
    public int Fibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    /// <summary>
    /// https://stackoverflow.com/a/13001749
    /// </summary>
    /// <param name="n">find x prime numbers</param>
    /// <returns></returns>
    public long FindPrimeNumber(int n)
    {
        int count = 0;
        long a = 2;
        while (count < n)
        {
            long b = 2;
            int prime = 1;// to check if found a prime
            while (b * b <= a)
            {
                if (a % b == 0)
                {
                    prime = 0;
                    break;
                }
                b++;
            }
            if (prime > 0)
            {
                count++;
            }
            a++;
        }
        return (--a);
    }

    /// <summary>
    /// https://stackoverflow.com/a/13001661
    /// </summary>
    /// <param name="miliSeconds"></param>
    /// <returns></returns>
    public long Waiting(int miliSeconds)
    {
        var endTime = DateTime.Now.AddMilliseconds(miliSeconds);

        while (true)
        {
            if (DateTime.Now >= endTime)
                break;
        }

        return endTime.Ticks;
    }
}