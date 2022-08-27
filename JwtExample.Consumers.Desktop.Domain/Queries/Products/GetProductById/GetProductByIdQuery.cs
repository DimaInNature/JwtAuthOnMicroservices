namespace JwtExample.Consumers.Desktop.Domain.Queries.Products;

public sealed record GetProductByIdQuery
    : BaseAuthorizedFeature, IRequest<Product?>
{
    public Guid Id { get; }

    public GetProductByIdQuery(Guid id, string token) =>
        (Id, Token) = (id, token);

    public GetProductByIdQuery() { }
}