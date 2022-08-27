namespace JwtExample.Consumers.Desktop.Domain.Commands.Users;

public sealed record CreateUserCommand
    : BaseAnonymousFeature, IRequest<User?>
{
    public User? User { get; }

    public CreateUserCommand(User entity) =>
        User = entity;

    public CreateUserCommand() { }
}