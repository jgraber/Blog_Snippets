namespace MemoryFiller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fill Memory");

            var keep = new List<byte[]>();

            do
            {
                Console.WriteLine(" + 100mb allocated - exit with e, continue with everything else");

                byte[] data = new byte[1024 * 1024 * 100];
                Array.Clear(data, 0, data.Length);
                keep.Add(data);

                var exit = Console.ReadKey();
                if (exit.KeyChar.ToString().Equals("e"))
                {
                    break;
                }

            } while (true);
        }
    }
}
