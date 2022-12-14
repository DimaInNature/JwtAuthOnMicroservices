namespace JwtExample.Microservices.AuthService.Infra.IoC;

public static class ApplicationConfiguration
{
    public static void AddConfigurationFrom(this IServiceCollection services, string path)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        if (string.IsNullOrWhiteSpace(value: path)) throw new ArgumentException(message: nameof(path));

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(basePath: Directory.GetCurrentDirectory())
            .AddJsonFile(path, optional: false, reloadOnChange: true)
            .Build();

        // for IOptions
        services.Configure<ApplicationSettingsModel>(configuration);
    }
}