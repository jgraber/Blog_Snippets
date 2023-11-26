using System.Runtime.CompilerServices;
using RSSProducer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<TimedHostedService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    var mimeType = "application/rss+xml; charset=utf-8";
    var bytes = FeedCreator.CreateFeed().ToArray();
    return Results.File(bytes, contentType: mimeType);
});

app.MapGet("/feed.rss", () =>
{
    var mimeType = "application/rss+xml; charset=utf-8";
    var feed = File.ReadAllBytes("feedExample.txt");
    return Results.File(feed, contentType: mimeType);
});

app.MapGet("/people", () =>
{
    var mimeType = "application/json; charset=utf-8";
    var feed = File.ReadAllBytes("people.json");
    return Results.File(feed, contentType: mimeType);
});

app.Run();