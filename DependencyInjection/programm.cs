using System;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register services with an intentional error:
// Baz is required but never registered.
services.AddTransient<Foo>();
services.AddTransient<Bar>();

try
{
    var serviceProvider = services.BuildServiceProvider(
        new ServiceProviderOptions
        {
            ValidateOnBuild = true,
            ValidateScopes = true
        });
}
catch (Exception ex)
{
    Console.WriteLine("DI validation failed at build time:");
    Console.WriteLine(ex.Message);
}

public class Foo
{
    public Foo(Bar bar) { }
}

public class Bar
{
    public Bar(Baz baz) { }
}

public class Baz
{
}
