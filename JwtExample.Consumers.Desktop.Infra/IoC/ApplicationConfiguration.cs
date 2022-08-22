namespace JwtExample.Consumers.Desktop.Infra.IoC;

public static class ApplicationConfiguration
{
    public static void AddConfigurationFrom(
        this IServiceCollection services,
        string path,
        out ApplicationSettingsModel applicationSettings)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        if (string.IsNullOrWhiteSpace(value: path)) throw new ArgumentException(message: nameof(path));

        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(basePath: Directory.GetCurrentDirectory())
            .AddJsonFile(path, optional: false, reloadOnChange: true)
            .Build();

        services.AddSingleton(configuration);

        // for IOptions
        services.Configure<ApplicationSettingsModel>(configuration);

        applicationSettings = configuration.Get<ApplicationSettingsModel>();
    }
}