namespace JwtExample.Microservices.AuthService.Domain.Queries.Users;

public sealed record GetUserQuery
    : IRequest<UserEntity?>
{
    public Func<UserEntity, bool>? Predicate { get; }

    public GetUserQuery(
        Func<UserEntity, bool> predicate) =>
        Predicate = predicate;

    public GetUserQuery() { }
}