namespace JwtExample.Consumers.Desktop.Domain.Queries.Users;

public sealed record GetUserListQuery
    : BaseAuthorizedFeature, IRequest<IEnumerable<User>>
{
    public GetUserListQuery(string token) => Token = token;

    public GetUserListQuery() { }
}