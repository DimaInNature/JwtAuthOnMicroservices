namespace JwtExample.Microservices.UserService.Domain.Commands.Users;

public sealed record DeleteUserCommand : IRequest
{
    public Guid Id { get; }

    public DeleteUserCommand(Guid id) => Id = id;

    public DeleteUserCommand() { }
}