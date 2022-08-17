namespace JwtExample.Gateway.Desktop;

public class Program
{
    public static void Main(string[] args) =>
        CreateHostBuilder(args)
        .Build()
        .Run();

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.ConfigureAppConfiguration(configureDelegate:
                   config => config.AddJsonFile(path: $"ocelot.json"));
            });
}