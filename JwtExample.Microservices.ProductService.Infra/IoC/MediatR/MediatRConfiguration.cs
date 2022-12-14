namespace JwtExample.Microservices.ProductService.Infra.IoC.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services, paramName: nameof(services));

        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        services.AddProductMediatRProfile();
    }
}