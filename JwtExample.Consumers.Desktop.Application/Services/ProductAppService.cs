namespace JwtExample.Consumers.Desktop.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IMediator _mediator;

    public ProductAppService(IMediator mediator) =>
        _mediator = mediator;

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Product?> CreateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}