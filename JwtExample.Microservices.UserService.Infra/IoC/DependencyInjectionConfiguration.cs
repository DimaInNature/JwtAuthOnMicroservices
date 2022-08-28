namespace JwtExample.Microservices.UserService.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services, paramName: nameof(services));

        services.AddScoped<IGenericRepository<UserEntity>, GenericRepository<UserEntity>>();

        services.AddScoped<IUserAppService, UserAppService>();

        services.Decorate<IUserAppService, UserAppServiceLogger>();
    }
}