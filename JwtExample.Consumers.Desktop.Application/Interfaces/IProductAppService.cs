namespace JwtExample.Consumers.Desktop.Application.Interfaces;

public interface IProductAppService
{
    public Task<IEnumerable<Product>> GetAllAsync(string token);

    public Task<Product?> GetAsync(Guid id, string token);

    public Task<Product?> CreateAsync(Product entity, string token);

    public Task UpdateAsync(Product entity, string token);

    public Task DeleteAsync(Guid id, string token);
}