namespace JwtExample.Consumers.Desktop.Domain.Commands.Users;

public sealed record DeleteUserCommand
    : BaseAuthorizedFeature, IRequest
{
    public Guid Id { get; }

    public DeleteUserCommand(Guid id, string token) =>
        (Id, Token) = (id, token);

    public DeleteUserCommand() { }
}