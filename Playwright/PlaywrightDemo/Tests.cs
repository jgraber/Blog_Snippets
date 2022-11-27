using System.Text.RegularExpressions;

using Microsoft.Playwright.NUnit;

namespace PlaywrightDemo;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task FirstStep()
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
    public async Task GetText()
    {
        await Page.GotoAsync("https://improveandrepeat.com/about/");

        var allText = await Page.Locator("article").AllInnerTextsAsync();
        foreach (var text in allText)
        {
            Console.WriteLine(text);
        }
    }

    [Test]
    public async Task Where()
    {
        await Page.GotoAsync("https://www.whatismybrowser.com/");

        var version = await Page.Locator("#primary-browser-detection")
                            .InnerTextAsync();
        Console.WriteLine(version);
    }
}