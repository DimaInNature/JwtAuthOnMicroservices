namespace JwtExample.Consumers.Desktop.Domain.Queries.Users;

public sealed record GetUserListQuery
    : IRequest<IEnumerable<User>>
{

}