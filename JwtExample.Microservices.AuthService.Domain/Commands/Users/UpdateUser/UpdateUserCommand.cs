namespace JwtExample.Microservices.AuthService.Domain.Commands.Users;

public sealed record UpdateUserCommand : IRequest
{
    public UserEntity? User { get; }

    public UpdateUserCommand(UserEntity entity) => User = entity;

    public UpdateUserCommand() { }
}