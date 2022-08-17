var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    // .NET Native DI Abstraction
    services.AddServices();

    services.AddControllers();
}

void Configure(WebApplication app)
{
    app.MapControllers();
}