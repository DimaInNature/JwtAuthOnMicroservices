namespace JwtExample.Microservices.ProductService.Persistence.IoC;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, ProductServiceDbContext>();

        services.AddDbContextPool<ProductServiceDbContext>(options =>
        {
            options.UseSqlite(connectionString: configuration.GetConnectionString(name: "Sqlite"));
        });
    }
}