namespace JwtExample.Consumers.Desktop.Application.Interfaces;

public interface IProductAppService
{
    public Task<Product?> GetAsync(Guid id);

    public Task<IEnumerable<Product>> GetAllAsync();

    public Task<Product?> CreateAsync(Product entity);

    public Task UpdateAsync(Product entity);

    public Task DeleteAsync(Guid id);
}