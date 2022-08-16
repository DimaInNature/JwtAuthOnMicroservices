var builder = WebApplication.CreateBuilder(args);

RegisterServices(services: builder.Services);

var app = builder.Build();

Configure(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    // Logging
    services.AddLoggingConfiguration(hostBuilder: builder.Host);

    // Setting DBContext
    services.AddDatabaseConfiguration(configuration: builder.Configuration);

    // Swagger
    services.AddSwaggerConfiguration();

    // .NET Native DI Abstraction
    services.AddServices();

    // MediatR
    services.AddMediatRConfiguration();

    services.AddControllers();
}

void Configure(WebApplication app)
{
    app.UseHttpsRedirection();

    app.MapControllers();

    app.UseSwaggerSetup();
}