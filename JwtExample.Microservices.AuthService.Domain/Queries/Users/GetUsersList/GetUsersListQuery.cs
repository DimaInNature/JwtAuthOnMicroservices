namespace JwtExample.Microservices.AuthService.Domain.Queries.Users;

public sealed record GetUsersListQuery
    : IRequest<IEnumerable<UserEntity>>
{
    public Func<UserEntity, bool>? Predicate { get; }

    public GetUsersListQuery(
        Func<UserEntity, bool> predicate) =>
        Predicate = predicate;

    public GetUsersListQuery() { }
}