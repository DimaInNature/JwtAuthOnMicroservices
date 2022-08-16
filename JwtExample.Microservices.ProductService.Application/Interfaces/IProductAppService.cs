namespace JwtExample.Microservices.ProductService.Application.Interfaces;

public interface IProductAppService
{
    public Task<IEnumerable<ProductEntity>> GetAllAsync();

    public Task<IEnumerable<ProductEntity>> GetAllAsync(Func<ProductEntity, bool> predicate);

    public Task<ProductEntity?> GetAsync(Guid id);

    public Task<ProductEntity?> GetAsync(Func<ProductEntity, bool> predicate);

    public Task CreateAsync(ProductEntity entity);

    public Task UpdateAsync(ProductEntity entity);

    public Task DeleteAsync(Guid id);
}