using FlexibleFizzBuzzFunctions.Models;
using FlexibleFizzBuzzFunctions.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration((context, configuration) =>
    {
        configuration.AddJsonFile("appsettings.json");
    })
    .ConfigureServices((context, services) =>
    {
        services.Configure<SolverOptions>(context.Configuration.GetSection("di"));
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<IFizzBuzzSolver, FlexibleFizzBuzzSolver>();
    })
    .Build();

host.Run();
