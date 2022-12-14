namespace JwtExample.Microservices.AuthService.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services, paramName: nameof(services));

        services.AddSingleton<JwtTokenHandler>();

        services.AddScoped<IGenericRepository<UserEntity>, GenericRepository<UserEntity>>();

        services.AddScoped<IUsersService, UsersService>();
    }
}