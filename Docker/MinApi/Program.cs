using Dapper;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/{name}", (string name) => HelloHandler.Hello(name));

app.Run();

class HelloHandler
{
    public static string Hello(string name = "static method")
    {
        return $"Hello {name}";
    }
}
