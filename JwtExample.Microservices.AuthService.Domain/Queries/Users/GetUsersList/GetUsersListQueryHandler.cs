namespace JwtExample.Microservices.AuthService.Domain.Queries.Users;

public sealed record GetUsersListQueryHandler
    : IRequestHandler<GetUsersListQuery, IEnumerable<UserEntity>>
{
    private readonly IGenericRepository<UserEntity> _repository;

    public GetUsersListQueryHandler(
        IGenericRepository<UserEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<UserEntity>> Handle(
        GetUsersListQuery request,
        CancellationToken token) =>
        request.Predicate is null
        ? _repository.GetAll()
        : _repository.GetAll(predicate: request.Predicate);
}