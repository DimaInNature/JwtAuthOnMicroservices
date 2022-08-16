namespace JwtExample.Microservices.ProductService.Domain.Queries.Products;

public sealed record class GetProductsListQueryHandler
    : IRequestHandler<GetProductsListQuery, IEnumerable<ProductEntity>>
{
    private readonly IGenericRepository<ProductEntity> _repository;

    public GetProductsListQueryHandler(
        IGenericRepository<ProductEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<ProductEntity>> Handle(
        GetProductsListQuery request,
        CancellationToken token) =>
        request.Predicate is null
        ? _repository.GetAll()
        : _repository.GetAll(predicate: request.Predicate);
}