namespace JwtExample.Consumers.Desktop.Domain.Queries.Users;

public sealed record GetUserListQueryHandler
    : IRequestHandler<GetUserListQuery, IEnumerable<User>>
{
    private readonly HttpClient _httpClient;

    public GetUserListQueryHandler(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<IEnumerable<User>> Handle(
        GetUserListQuery request,
        CancellationToken cancellationToken)
    {
        return default;
    }
}