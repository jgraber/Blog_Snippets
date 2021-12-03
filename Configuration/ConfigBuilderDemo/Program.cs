using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConfigBuilderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings_1.json", true, true)
                .AddJsonFile("appsettings_2.json", true, true);
            //.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "..", "appsettings.json"), true, true)
            //.AddEnvironmentVariables();

            var configuration = builder.Build();

            Console.WriteLine(configuration["AppSettings:myKey"]);
        }
    }
}
