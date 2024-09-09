using Serilog;

namespace WebApp.Helper
{
    public class Logic
    {
        public int A(int input)
        {
            Log.Information("Enter A");
            Thread.Sleep(50);
            input += B(input);
            return input;
        }

        public int B(int input)
        {
            Log.Information("Enter B");
            Thread.Sleep(50);
            input += C(input);
            return input;
        }

        public int C(int input)
        {
            Log.Information("Enter C");
            Thread.Sleep(50);
            input += D(input);
            return input;
        }

        public int D(int input)
        {
            Log.Information("Enter D");
            Thread.Sleep(50);
            input += 2;
            return input;
        }
    }
}
