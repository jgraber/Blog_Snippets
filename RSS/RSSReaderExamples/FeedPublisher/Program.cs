using System.Runtime.CompilerServices;
using RSSProducer;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    var mimeType = "application/rss+xml; charset=utf-8";
    var bytes = FeedCreator.CreateFeed().ToArray();
    return Results.File(bytes, contentType: mimeType);
});

app.Run();