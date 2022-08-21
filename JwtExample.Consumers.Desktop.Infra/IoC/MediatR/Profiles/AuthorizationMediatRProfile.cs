namespace JwtExample.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

public static class AuthorizationMediatRProfile
{
    public static void AddAuthorizationMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddScoped<IRequest<LoginAuthenticationResponse?>, AuthorizationByUsernameAndPasswordQuery>();
        services.AddScoped<IRequestHandler<AuthorizationByUsernameAndPasswordQuery, LoginAuthenticationResponse?>, AuthorizationByUsernameAndPasswordQueryHandler>();
    }
}