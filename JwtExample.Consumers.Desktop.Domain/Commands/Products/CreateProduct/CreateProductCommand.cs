namespace JwtExample.Consumers.Desktop.Domain.Commands.Products;

public sealed record CreateProductCommand
	: BaseAuthorizedFeature, IRequest<Product?>
{
	public Product? Product { get; }

	public CreateProductCommand(Product entity, string token) =>
		(Product, Token) = (entity, token);

	public CreateProductCommand() { }
}