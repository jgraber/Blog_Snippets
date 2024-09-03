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
}