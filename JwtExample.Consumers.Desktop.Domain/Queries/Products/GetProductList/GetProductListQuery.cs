namespace JwtExample.Consumers.Desktop.Domain.Queries.Products;

public sealed record GetProductListQuery
	: BaseAuthorizedFeature, IRequest<IEnumerable<Product>>
{
	public GetProductListQuery(string token) =>
		Token = token;

	public GetProductListQuery() { }
}