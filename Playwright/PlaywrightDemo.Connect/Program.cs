using Microsoft.Playwright;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using dotenv.net;
using static System.Net.WebRequestMethods;

class Program
{
    public static async Task Main(string[] args)
    {
        //await BrowserStack();
        await SeleniumGrid();
    }

    private static async Task SeleniumGrid()
    {
        Environment.SetEnvironmentVariable("SELENIUM_REMOTE_URL", 
            "http://localhost:4444/wd/hub");

        using var playwright = await Playwright.CreateAsync();

        await using var browser = await playwright.Chromium.LaunchAsync();
        var context = await browser.NewContextAsync(
                            new()
                                {
                                    RecordVideoDir = "videos/", 
                                    Locale = "en-GB"
                                });

        var page = await context.NewPageAsync();
        await page.GotoAsync("chrome://version/");
        Thread.Sleep(5000);


        await page.GotoAsync("https://www.google.com/");

        await page.GetByRole(AriaRole.Button, new()
                                                    {
                                                        NameString = "Accept all"
                                                    }).ClickAsync();
        await page.WaitForURLAsync("https://www.google.com/");

        await page.Locator("[aria-label='Search']").ClickAsync();
        await page.FillAsync("[aria-label='Search']", "BrowserStack");
        await page.Locator("[aria-label='Google Search'] >> nth=0").ClickAsync();
        var title = await page.TitleAsync();


        await browser.CloseAsync();
    }

    private static async Task BrowserStack()
    {
        DotEnv.Load();
        var envVars = DotEnv.Read();

        using var playwright = await Playwright.CreateAsync();

        Dictionary<string, string> browserstackOptions = new Dictionary<string, string>();
        browserstackOptions.Add("name", "Playwright first sample test");
        browserstackOptions.Add("build", "playwright-dotnet-1");
        browserstackOptions.Add("os", "osx");
        browserstackOptions.Add("os_version", "catalina");
        // allowed browsers are `chrome`, `edge`, `playwright-chromium`,
        // `playwright-firefox` and `playwright-webkit`
        browserstackOptions.Add("browser", "chrome");
        browserstackOptions.Add("browserstack.username", envVars["username"]);
        browserstackOptions.Add("browserstack.accessKey", envVars["accessKey"]);
        string capsJson = JsonConvert.SerializeObject(browserstackOptions);
        string cdpUrl = "wss://cdp.browserstack.com/playwright?caps=" 
                        + Uri.EscapeDataString(capsJson);

        await using var browser = await playwright.Chromium.ConnectAsync(cdpUrl);
        var page = await browser.NewPageAsync(new BrowserNewPageOptions() 
                                                  { Locale = "en-GB" });
        try
        {
            await page.GotoAsync("https://www.google.com/");

            await page.GetByRole(AriaRole.Button, new()
                                                      {
                                                          NameString = "Accept all"
                                                      }).ClickAsync();
            await page.WaitForURLAsync("https://www.google.com/");

            await page.Locator("[aria-label='Search']").ClickAsync();
            await page.FillAsync("[aria-label='Search']", "BrowserStack");
            await page.Locator("[aria-label='Google Search'] >> nth=0").ClickAsync();
            var title = await page.TitleAsync();

            if (title == "BrowserStack - Google Search")
            {
                // following line of code is responsible for marking the status of the
                // test on BrowserStack as 'passed'. You can use this code in your after
                // hook after each test
                await MarkTestStatus("passed", "Title matched", page);
            }
            else
            {
                await MarkTestStatus("failed", "Title did not match", page);
            }
        }
        catch (Exception err)
        {
            await MarkTestStatus("failed", err.Message, page);
        }

        await browser.CloseAsync();
    }

    public static async Task MarkTestStatus(string status, string reason, IPage page)
    {
        await page.EvaluateAsync("_ => {}", 
            "browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\":" +
            " {\"status\":\"" + status + "\", \"reason\": \"" + reason + "\"}}");
    }
}
