namespace JwtExample.Consumers.Desktop.Domain.Commands.Users;

public sealed record UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
{
    private readonly HttpClient _httpClient;

    public UpdateUserCommandHandler(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<Unit> Handle(
        UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        if (request.User is null) return default;

        return default;
    }
}