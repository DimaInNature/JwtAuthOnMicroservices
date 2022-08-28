namespace JwtExample.Microservices.UserService.Domain.Queries.Users;

public sealed record GetUserQueryHandler
    : IRequestHandler<GetUserQuery, UserEntity?>
{
    private readonly IGenericRepository<UserEntity> _repository;

    public GetUserQueryHandler(
        IGenericRepository<UserEntity> repository) =>
        _repository = repository;

    public async Task<UserEntity?> Handle(
        GetUserQuery request,
        CancellationToken token) =>
        request.Predicate is null
        ? default
        : _repository.GetFirstOrDefault(predicate: request.Predicate);
}