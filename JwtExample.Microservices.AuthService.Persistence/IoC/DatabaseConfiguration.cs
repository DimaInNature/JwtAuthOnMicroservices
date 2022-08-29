public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, AuthServiceDbContext>();

        services.AddDbContextPool<AuthServiceDbContext>(options =>
        {
            options.UseSqlite(connectionString: configuration.GetConnectionString(name: "Sqlite"));
        });
    }
}