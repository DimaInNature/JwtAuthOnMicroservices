namespace JwtExample.Consumers.Desktop.Domain.Commands.Users;

public sealed record CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, User?>
{
    private readonly HttpClient _httpClient;

    public CreateUserCommandHandler(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<User?> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        if (request.User is null) return default;

        return default;
    }
}