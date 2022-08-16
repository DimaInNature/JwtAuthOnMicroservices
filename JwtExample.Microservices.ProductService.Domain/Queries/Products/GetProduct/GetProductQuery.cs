namespace JwtExample.Microservices.ProductService.Domain.Queries.Products;

public sealed record class GetProductQuery
    : IRequest<ProductEntity?>
{
    public Func<ProductEntity, bool>? Predicate { get; }

    public GetProductQuery(
        Func<ProductEntity, bool> predicate) =>
        Predicate = predicate;

    public GetProductQuery() { }
}