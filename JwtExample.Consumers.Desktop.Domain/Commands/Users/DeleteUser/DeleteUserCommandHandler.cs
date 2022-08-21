namespace JwtExample.Consumers.Desktop.Domain.Commands.Users;

public sealed record DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand>
{
    private readonly HttpClient _httpClient;

    public DeleteUserCommandHandler(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<Unit> Handle(
        DeleteUserCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty) return default;

        return default;
    }
}