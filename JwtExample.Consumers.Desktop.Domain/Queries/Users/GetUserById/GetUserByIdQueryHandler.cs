namespace JwtExample.Consumers.Desktop.Domain.Queries.Users;

public sealed record GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, User?>
{
    private readonly HttpClient _httpClient;

    public GetUserByIdQueryHandler(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<User?> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty) return default;

        return default;
    }
}