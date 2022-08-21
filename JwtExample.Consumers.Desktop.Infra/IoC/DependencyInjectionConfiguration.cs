namespace JwtExample.Consumers.Desktop.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: nameof(services));

        services.AddSingleton<UserSessionService>();

        services.AddTransient<IUserAppService, UserAppService>();

        services.AddTransient<IAuthenticationAppService, AuthenticationAppService>();

        services.AddTransient<IProductAppService, ProductAppService>();
    }
}