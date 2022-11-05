using System.Text.RegularExpressions;

using Microsoft.Playwright.NUnit;

namespace PlaywrightDemo;

using Microsoft.Playwright;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class TraceTest : PageTest
{
    [SetUp]
    public async Task TestSetup()
    {
        var properties = TestContext.CurrentContext.Test.Properties;

        if (properties.ContainsKey("Category") && (string)properties.Get("Category")! == "TraceIt")
        {
            await Context.Tracing.StartAsync(
                new TracingStartOptions
                    {
                        Screenshots = true,
                        Snapshots = true,
                        Sources = true,
                        Name = TestContext.CurrentContext.Test.FullName
                    });
        }
    }

    [TearDown]
    public async Task TestCleanup()
    {
        var properties = TestContext.CurrentContext.Test.Properties;

        if (properties.ContainsKey("Category") && (string)properties.Get("Category")! == "TraceIt")
        {
            await Context.Tracing.StopAsync(
                new TracingStopOptions { Path = TestContext.CurrentContext.Test.FullName + ".zip" });
        }
    }

    [Test]
    [Category("TraceIt")]
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
    [Category("TraceIt")]
    public async Task MissingText()
    {
        await Page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("PlaywrightXYZ"));
    }
}
