using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var config = app.Services.GetRequiredService<IConfiguration>();
var connectionString = config.GetConnectionString("Adventure");
Console.WriteLine(connectionString);
var sqlCon = new SqlConnection(connectionString);
var emplyeeHandler = new EmployeeHandler(sqlCon);

app.MapGet("/", () => "Welcome!");

app.MapGet("/employee/{id}", (int id) => emplyeeHandler.FindById(id));

app.Run("http://+:7000");

class EmployeeHandler
{
    private readonly SqlConnection connection;

    public EmployeeHandler(SqlConnection connection)
    {
        this.connection = connection;
    }

    public Person FindById(int id)
    {
        var query = @"SELECT [BusinessEntityID] AS [Id]
                          ,[FirstName]
                          ,[LastName]
                          ,[ModifiedDate]
                      FROM [AdventureWorks2019].[Person].[Person]
                      WHERE BusinessEntityID = @id";

        var result = connection.Query<Person>(query, new { id }).First();
        
        return result;
    }
}

public record Person(int Id, string FirstName, string LastName, DateTime ModifiedDate);
