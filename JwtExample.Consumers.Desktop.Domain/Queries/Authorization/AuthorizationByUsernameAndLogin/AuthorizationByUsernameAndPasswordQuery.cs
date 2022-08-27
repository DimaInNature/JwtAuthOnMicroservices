namespace JwtExample.Consumers.Desktop.Domain.Queries.Authorization;

public record AuthorizationByUsernameAndPasswordQuery
    : BaseAnonymousFeature, IRequest<LoginAuthenticationResponse?>
{
    public LoginAuthenticationRequest? Request { get; }

    public AuthorizationByUsernameAndPasswordQuery(
        LoginAuthenticationRequest request) => Request = request;

    public AuthorizationByUsernameAndPasswordQuery() { }
}