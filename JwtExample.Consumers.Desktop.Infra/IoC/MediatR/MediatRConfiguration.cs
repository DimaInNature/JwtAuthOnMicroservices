namespace JwtExample.Consumers.Desktop.Infra.IoC.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        services.AddUserMediatRProfile();

        services.AddProductMediatRProfile();

        services.AddAuthorizationMediatRProfile();
    }
}