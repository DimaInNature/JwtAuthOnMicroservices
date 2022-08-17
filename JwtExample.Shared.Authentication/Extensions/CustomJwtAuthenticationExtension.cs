namespace JwtExample.Shared.Authentication.Extensions;

public static class CustomJwtAuthenticationExtension
{
    public static void AddCustomJwtAuthentication(
        this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services, paramName: nameof(services));

        services.AddAuthentication(configureOptions: options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;

            options.TokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(s: JwtTokenHandler.KEY))
            };
        });
    }
}