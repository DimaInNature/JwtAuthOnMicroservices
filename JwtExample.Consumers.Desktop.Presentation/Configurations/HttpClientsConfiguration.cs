namespace JwtExample.Consumers.Desktop.Presentation.Configurations;

public static class HttpClientsConfiguration
{
    public static void AddHttpClientsConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services, paramName: nameof(services));

        services.AddHttpClient<IRequestHandler<AuthorizationByUsernameAndPasswordQuery, LoginAuthenticationResponse?>,
            AuthorizationByUsernameAndPasswordQueryHandler>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001");
            });
    }
}