var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/people", () =>
{
    var mimeType = "application/json; charset=utf-8";
    var testData = File.ReadAllBytes("people.json");
    return Results.File(testData, contentType: mimeType);
});

app.Run();