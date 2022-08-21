namespace JwtExample.Consumers.Desktop.Domain.Queries.Authorization;

public record AuthorizationByUsernameAndPasswordQuery
    : IRequest<LoginAuthenticationResponse?>
{
    public LoginAuthenticationRequest? Request { get; }

    public AuthorizationByUsernameAndPasswordQuery(
        LoginAuthenticationRequest request) =>
        Request = request;

    public AuthorizationByUsernameAndPasswordQuery() { }
}