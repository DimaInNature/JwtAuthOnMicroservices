namespace JwtExample.Consumers.Desktop.Domain.Queries.Products;

public sealed record GetProductListQuery : IRequest<IEnumerable<Product>>
{

}