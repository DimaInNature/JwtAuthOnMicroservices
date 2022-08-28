namespace JwtExample.Microservices.UserService.Domain.Commands.Users;

public sealed record UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
{
    private readonly IGenericRepository<UserEntity> _repository;

    public UpdateUserCommandHandler(
        IGenericRepository<UserEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        UpdateUserCommand request,
        CancellationToken token)
    {
        if (request.User is null) return default;

        await _repository.UpdateAsync(entity: request.User, token);

        return default;
    }
}