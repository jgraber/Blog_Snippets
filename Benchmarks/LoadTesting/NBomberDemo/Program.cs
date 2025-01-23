using System.Net;
using NBomber.CSharp;
using NBomber.Http;

namespace MyLoadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using var httpClient = new HttpClient();

            var slow = Scenario.Create("Slow", async context =>
                {
                    var response = await httpClient.GetAsync("https://localhost:7285/Speed/Slow");

                    return response.IsSuccessStatusCode
                        ? Response.Ok<string>(statusCode: response.StatusCode.ToString())
                        : Response.Fail<string>(statusCode: response.StatusCode.ToString());
                })
                .WithWarmUpDuration(TimeSpan.FromSeconds(5))
                .WithLoadSimulations(
                    Simulation.RampingInject(rate: 1000,
                        interval: TimeSpan.FromSeconds(1),
                        during: TimeSpan.FromSeconds(20)),
                    Simulation.Inject(rate: 1000,
                        interval: TimeSpan.FromSeconds(1),
                        during: TimeSpan.FromSeconds(60)),
                    Simulation.RampingInject(rate: 0,
                        interval: TimeSpan.FromSeconds(1),
                        during: TimeSpan.FromSeconds(10))
                );

            var asyncSlow = Scenario.Create("AsyncSlow", async context =>
                {
                    var response = await httpClient.GetAsync("https://localhost:7285/Speed/AsyncSlow");

                    return response.IsSuccessStatusCode
                        ? Response.Ok<string>(statusCode:response.StatusCode.ToString())
                        : Response.Fail<string>(statusCode: response.StatusCode.ToString());
                })
                .WithWarmUpDuration(TimeSpan.FromSeconds(5))
                .WithLoadSimulations(
                    Simulation.RampingInject(rate: 1000,
                        interval: TimeSpan.FromSeconds(1),
                        during: TimeSpan.FromSeconds(20)),
                    Simulation.Inject(rate: 1000,
                        interval: TimeSpan.FromSeconds(1),
                        during: TimeSpan.FromSeconds(60)),
                    Simulation.RampingInject(rate: 0,
                        interval: TimeSpan.FromSeconds(1),
                        during: TimeSpan.FromSeconds(10))
                );

            NBomberRunner
                .RegisterScenarios(slow)
                .WithWorkerPlugins(new HttpMetricsPlugin(new[] { NBomber.Http.HttpVersion.Version1 }))
                //.WithReportFormats(ReportFormat.Html)
                //.WithReportFolder("Reports")
                .Run();
        }
    }
}