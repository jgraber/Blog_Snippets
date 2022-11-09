using Microsoft.Playwright;

class Program
{
    public static async Task Main()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(
                                      new BrowserTypeLaunchOptions
                                          {
                                              Headless = false,
                                          });
        var context = await browser.NewContextAsync(
                        new()
                        {
                            RecordVideoDir = "videos/"
                        });
        

        var Page = await context.NewPageAsync();

        await Page.GotoAsync("https://improveandrepeat.com/");

        await Page.ScreenshotAsync(new()
                                       {
                                           Path = "screenshot_view.png",
                                       });


        await Page.ScreenshotAsync(new()
                                {
                                    Path = "screenshot_full.png",
                                    FullPage = true,
                                });

        await context.CloseAsync();

    }
}