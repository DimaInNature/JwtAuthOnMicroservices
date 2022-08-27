namespace JwtExample.Consumers.Desktop.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IMediator _mediator;

    public UserAppService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<IEnumerable<User>> GetAllAsync(string token) =>
        await _mediator.Send(request: new GetUserListQuery(token));

    public async Task<User?> GetAsync(Guid id, string token) =>
        await _mediator.Send(request: new GetUserByIdQuery(id, token));

    public async Task<User?> CreateAsync(User entity) =>
        await _mediator.Send(request: new CreateUserCommand(entity));

    public async Task UpdateAsync(User entity, string token) =>
        await _mediator.Send(request: new UpdateUserCommand(entity, token));

    public async Task DeleteAsync(Guid id, string token) =>
        await _mediator.Send(request: new DeleteUserCommand(id, token));
}