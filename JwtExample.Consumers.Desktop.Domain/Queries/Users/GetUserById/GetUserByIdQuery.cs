namespace JwtExample.Consumers.Desktop.Domain.Queries.Users;

public sealed record GetUserByIdQuery
    : BaseAuthorizedFeature, IRequest<User?>
{
    public Guid Id { get; }

    public GetUserByIdQuery(Guid id, string token) =>
        (Id, Token) = (id, token);

    public GetUserByIdQuery() { }
}