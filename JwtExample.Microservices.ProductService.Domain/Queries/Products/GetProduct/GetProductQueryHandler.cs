namespace JwtExample.Microservices.ProductService.Domain.Queries.Products;

public sealed record class GetProductQueryHandler
    : IRequestHandler<GetProductQuery, ProductEntity?>
{
    private readonly IGenericRepository<ProductEntity> _repository;

    public GetProductQueryHandler(
        IGenericRepository<ProductEntity> repository) =>
        _repository = repository;

    public async Task<ProductEntity?> Handle(
        GetProductQuery request,
        CancellationToken token) =>
        request.Predicate is null
        ? default
        : _repository.GetFirstOrDefault(predicate: request.Predicate);
}