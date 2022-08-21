namespace JwtExample.Consumers.Desktop.Domain.Commands.Users;

public sealed record UpdateUserCommand : IRequest
{
    public User? User { get; }

    public UpdateUserCommand(User entity) => User = entity;

    public UpdateUserCommand() { }
}