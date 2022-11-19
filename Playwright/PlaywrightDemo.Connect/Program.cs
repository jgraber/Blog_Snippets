// See https://aka.ms/new-console-template for more information
using dotenv.net;

Console.WriteLine("Hello, World!");

DotEnv.Load();
var envVars = DotEnv.Read();

Console.WriteLine(envVars["browserstack.username"]);
