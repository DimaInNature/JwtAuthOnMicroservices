namespace JwtExample.Gateway.Desktop;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOcelot()
            .AddCacheManager(settings => settings.WithDictionaryHandle());

        services.AddCustomJwtAuthentication();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseOcelot();
    }
}