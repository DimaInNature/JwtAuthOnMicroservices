namespace JwtExample.Consumers.Desktop.Application.Services;

public class AuthenticationAppService : IAuthenticationAppService
{
    private readonly IMediator _mediator;

    public AuthenticationAppService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<LoginAuthenticationResponse?> AuthorizeAsync(
        LoginAuthenticationRequest request) =>
        await _mediator.Send(request: new AuthorizationByUsernameAndPasswordQuery(request));
}