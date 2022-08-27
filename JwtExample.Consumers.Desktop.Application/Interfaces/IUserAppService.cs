namespace JwtExample.Consumers.Desktop.Application.Interfaces;

public interface IUserAppService
{
    public Task<User?> GetAsync(Guid id, string token);

    public Task<IEnumerable<User>> GetAllAsync(string token);

    public Task<User?> CreateAsync(User entity);

    public Task UpdateAsync(User entity, string token);

    public Task DeleteAsync(Guid id, string token);
}