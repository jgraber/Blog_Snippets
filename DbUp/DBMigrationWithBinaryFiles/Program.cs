using System.Reflection;
using DbUp;

namespace WithBinary
{
    public class Program
    {
        static int Main(string[] args)
        {
            var connectionString = "Data Source=.;Initial Catalog=Demo;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=False;";

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsAndCodeEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .WithTransactionPerScript()
                    .WithVariablesDisabled()
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
