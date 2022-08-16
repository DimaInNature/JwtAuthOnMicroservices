namespace JwtExample.Microservices.ProductService.Application.Services;

public class ProductAppService : IProductAppService
{
    private readonly IMediator _mediator;

    public ProductAppService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<IEnumerable<ProductEntity>> GetAllAsync() =>
        await _mediator.Send(request: new GetProductsListQuery());

    public async Task<IEnumerable<ProductEntity>> GetAllAsync(
        Func<ProductEntity, bool> predicate) =>
        await _mediator.Send(request: new GetProductsListQuery(predicate));

    public async Task<ProductEntity?> GetAsync(Guid id) =>
        await _mediator.Send(request: new GetProductQuery(entity => entity.Id == id));

    public async Task<ProductEntity?> GetAsync(
        Func<ProductEntity, bool> predicate) =>
        await _mediator.Send(request: new GetProductQuery(predicate));

    public async Task CreateAsync(ProductEntity entity) =>
        await _mediator.Send(request: new CreateProductCommand(entity));

    public async Task UpdateAsync(ProductEntity entity) =>
        await _mediator.Send(request: new UpdateProductCommand(entity));

    public async Task DeleteAsync(Guid id) =>
        await _mediator.Send(request: new DeleteProductCommand(id));
}