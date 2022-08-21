var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    // Logging
    services.AddLoggingConfiguration(hostBuilder: builder.Host);

    services.AddConfigurationFrom(path: "appsettings.json");

    // .NET Native DI Abstraction
    services.AddServices();

    services.AddControllers();
}

void Configure(WebApplication app) => app.MapControllers();