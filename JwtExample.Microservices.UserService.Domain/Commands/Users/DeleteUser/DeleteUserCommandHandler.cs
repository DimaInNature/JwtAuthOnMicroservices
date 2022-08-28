namespace JwtExample.Microservices.UserService.Domain.Commands.Users;

public sealed record DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand>
{
    private readonly IGenericRepository<UserEntity> _repository;

    public DeleteUserCommandHandler(
        IGenericRepository<UserEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        DeleteUserCommand request,
        CancellationToken token)
    {
        if (request.Id.Equals(g: Guid.Empty)) return default;

        await _repository.DeleteAsync(key: request.Id, token);

        return default;
    }
}