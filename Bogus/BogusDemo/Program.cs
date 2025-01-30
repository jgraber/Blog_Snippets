using Bogus;

namespace BogusDemo;

public class Program
{
    public static void Main()
    {
        var faker = BasicExample();
        NeastedObjects(faker);
        CustomData();
        Seed();
        CheckConfiguration();
    }

    private static Faker<User> BasicExample()
    {
        var faker = new Faker<User>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.FullName, (f, u) => $"{u.FirstName} {u.LastName} ({u.Email})")
            .RuleFor(u => u.DateOfBirth, f => f.Date.Past(30, new DateTime(2000, 1, 1)));

        var users = faker.Generate(5); // Generate a list of 5 users

        foreach (var user in users)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName}, {user.Email}, {user.DateOfBirth:yyyy-MM-dd}");
            Console.WriteLine($"{user.FullName}\n");
        }

        Console.WriteLine("=======================================================");
        return faker;
    }

    private static void NeastedObjects(Faker<User> faker)
    {
        var orderFaker = new Faker<Order>()
            .RuleFor(o => o.Id, f => f.IndexFaker + 1)
            .RuleFor(o => o.ProductName, f => f.Commerce.ProductName())
            .RuleFor(o => o.Price, f => f.Finance.Amount(10, 500))
            .RuleFor(o => o.Customer, f => faker.Generate());

        var orders = orderFaker.Generate(5);

        foreach (var order in orders)
        {
            Console.WriteLine($@"{order.Id} - {order.ProductName} @ {order.Price} for {order.Customer.FullName}");
        }

        Console.WriteLine("=======================================================");
    }

    private static void CustomData()
    {
        var customFaker = new Faker<CustomData>()
            .RuleFor(c => c.Code, f => f.Random.AlphaNumeric(8))
            .RuleFor(c => c.Description, f => f.Lorem.Sentence())
            .RuleFor(c => c.IsVerified, f => f.Random.Bool())
            .RuleFor(c => c.Value, f=> f.Random.Even(max: 100));

        var customDataList = customFaker.Generate(3);
        foreach (var data in customDataList)
        {
            Console.WriteLine($"{data.Code} - {data.Description} - {data.IsVerified} - {data.Value}");
        }

        Console.WriteLine("=======================================================");
    }

    private static void Seed()
    {
        var seededFaker = new Faker<User>()
            .UseSeed(12345)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, f => f.Internet.Email());

        var seededUsers = seededFaker.Generate(5);
        foreach (var user in seededUsers)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} - {user.Email}");
        }

        Console.WriteLine("=======================================================");
    }

    private static void CheckConfiguration()
    {
        var customFaker = new Faker<CustomData>()
            .StrictMode(true)
            .RuleFor(c => c.Code, f => f.Random.AlphaNumeric(8));

        var customDataList = customFaker.Generate(3);
    }
}