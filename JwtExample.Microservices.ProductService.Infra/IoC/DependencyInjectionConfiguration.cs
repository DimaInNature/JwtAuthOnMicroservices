namespace JwtExample.Microservices.ProductService.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services, paramName: nameof(services));

        services.AddScoped<IGenericRepository<ProductEntity>, GenericRepository<ProductEntity>>();

        services.AddScoped<IProductAppService, ProductAppService>();

        services.Decorate<IProductAppService, ProductAppServiceLogger>();
    }
}