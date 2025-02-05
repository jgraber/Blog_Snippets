using NBomber.CSharp;
using NBomber.Http.CSharp;

using var httpClient = new HttpClient();

var scenario = Scenario.Create("http_scenario", async context =>
{
    var request =
        Http.CreateRequest("GET", "https://nbomber.com")
            .WithHeader("Accept", "text/html");
            

    var response = await Http.Send(httpClient, request);

    return response;
})
.WithoutWarmUp()
.WithLoadSimulations(
    Simulation.Inject(rate: 100,
                        interval: TimeSpan.FromSeconds(1),
                        during: TimeSpan.FromSeconds(30))
);
//.WithLoadSimulations(
//    Simulation.RampingInject(100,
//        interval: TimeSpan.FromSeconds(1),
//        during: TimeSpan.FromSeconds(20)),
//    Simulation.Inject(rate: 100,
//                        interval: TimeSpan.FromSeconds(1),
//                        during: TimeSpan.FromSeconds(20)),
//    Simulation.RampingInject(50,
//        interval: TimeSpan.FromSeconds(1),
//        during: TimeSpan.FromSeconds(20))
//);

var docs = Scenario.Create("docs_scenario", async context =>
{
    var request =
        Http.CreateRequest("GET", "https://nbomber.com/docs/getting-started/overview/")
            .WithHeader("Accept", "text/html");


    var response = await Http.Send(httpClient, request);

    return response;
})
.WithoutWarmUp()
.WithLoadSimulations(
    Simulation.Inject(rate: 100,
                        interval: TimeSpan.FromSeconds(1),
                        during: TimeSpan.FromSeconds(30))
);

NBomberRunner
    .RegisterScenarios(scenario, docs)
    .Run();