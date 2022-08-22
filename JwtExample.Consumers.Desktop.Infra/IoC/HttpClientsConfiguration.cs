namespace JwtExample.Consumers.Desktop.Infra.IoC;

public static class HttpClientsConfiguration
{
    public static void AddHttpClientsConfiguration(
        this IServiceCollection services,
        ApplicationSettingsModel applicationSettings)
    {
        ArgumentNullException.ThrowIfNull(argument: services, paramName: nameof(services));

        services.AddHttpClient<IRequestHandler<AuthorizationByUsernameAndPasswordQuery, LoginAuthenticationResponse?>,
            AuthorizationByUsernameAndPasswordQueryHandler>(client =>
            {
                client.BaseAddress = new(uriString: applicationSettings.Routes.GatewayRoute);
            });

        services.AddHttpClient<IRequestHandler<GetProductListQuery, IEnumerable<Product>>,
            GetProductListQueryHandler>(client =>
            {
                client.BaseAddress = new(uriString: applicationSettings.Routes.GatewayRoute);
            });
    }
}