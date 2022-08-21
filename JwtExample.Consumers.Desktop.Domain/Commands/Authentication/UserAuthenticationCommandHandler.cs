namespace JwtExample.Consumers.Desktop.Domain.Commands.Authentication;

public sealed record UserAuthenticationCommandHandler
    : IRequestHandler<UserAuthenticationCommand, string?>
{
    private readonly HttpClient _httpClient;

    public UserAuthenticationCommandHandler(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<string?> Handle(
        UserAuthenticationCommand request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}