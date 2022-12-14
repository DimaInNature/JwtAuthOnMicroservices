namespace JwtExample.Microservices.AuthService.Domain.Interfaces;

public interface IUsersService
{
    public Task<IEnumerable<UserEntity>> GetAllAsync();

    public Task<IEnumerable<UserEntity>> GetAllAsync(Func<UserEntity, bool> predicate);

    public Task<UserEntity?> GetAsync(Guid id);

    public Task<UserEntity?> GetAsync(Func<UserEntity, bool> predicate);

    public Task CreateAsync(UserEntity entity);

    public Task UpdateAsync(UserEntity entity);

    public Task DeleteAsync(Guid id);
}