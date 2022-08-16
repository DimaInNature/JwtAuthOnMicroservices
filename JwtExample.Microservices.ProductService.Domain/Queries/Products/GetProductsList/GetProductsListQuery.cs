namespace JwtExample.Microservices.ProductService.Domain.Queries.Products;

public sealed record class GetProductsListQuery
    : IRequest<IEnumerable<ProductEntity>>
{
    public Func<ProductEntity, bool>? Predicate { get; }

    public GetProductsListQuery(
        Func<ProductEntity, bool> predicate) =>
        Predicate = predicate;

    public GetProductsListQuery() { }
}