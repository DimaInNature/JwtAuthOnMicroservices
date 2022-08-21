namespace JwtExample.Consumers.Desktop.Domain.Queries.Users;

public sealed record GetUserByIdQuery : IRequest<User?>
{
    public Guid Id { get; }

    public GetUserByIdQuery(Guid id) => Id = id;

    public GetUserByIdQuery() { }
}