using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

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

}
