namespace JwtExample.Microservices.AuthService.Domain.Commands.Users;

public sealed record CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand>
{
    private readonly IGenericRepository<UserEntity> _repository;

    public CreateUserCommandHandler(
        IGenericRepository<UserEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        CreateUserCommand request,
        CancellationToken token)
    {
        if (request.User is null) return default;

        await _repository.CreateAsync(entity: request.User, token);

        return default;
    }
}