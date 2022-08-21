namespace JwtExample.Consumers.Desktop.Domain.Queries.Products;

public sealed record GetProductByIdQuery : IRequest<Product?>
{
    public Guid Id { get; }

    public GetProductByIdQuery(Guid id) => Id = id;

    public GetProductByIdQuery() { }
}