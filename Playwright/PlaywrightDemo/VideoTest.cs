using System.Text.RegularExpressions;

using Microsoft.Playwright.NUnit;

namespace PlaywrightDemo;

using Microsoft.Playwright;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class VideoTest : PageTest
{
    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions()
                   {
                       RecordVideoDir = "videos/",
                       ViewportSize = new ViewportSize {Height = 720, Width = 1280},
                       RecordVideoSize = new RecordVideoSize {Height = 720, Width = 1280}
                   };
    }

   
    [Test]
    public async Task LinkingToIntro()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = Page.Locator("text=Get Started");

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
    }

    [Test]
    public async Task MissingText()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("PlaywrightXYZ"));
    }
}
