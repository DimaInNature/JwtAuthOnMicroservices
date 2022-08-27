namespace JwtExample.Consumers.Desktop.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IMediator _mediator;

    public ProductAppService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<IEnumerable<Product>> GetAllAsync(string token) =>
        await _mediator.Send(request: new GetProductListQuery(token));

    public async Task<Product?> GetAsync(Guid id, string token) =>
        await _mediator.Send(request: new GetProductByIdQuery(id, token));

    public async Task<Product?> CreateAsync(Product entity, string token) =>
        await _mediator.Send(request: new CreateProductCommand(entity, token));

    public async Task UpdateAsync(Product entity, string token) =>
        await _mediator.Send(request: new UpdateProductCommand(entity, token));

    public async Task DeleteAsync(Guid id, string token) =>
        await _mediator.Send(request: new DeleteProductCommand(id, token));
}