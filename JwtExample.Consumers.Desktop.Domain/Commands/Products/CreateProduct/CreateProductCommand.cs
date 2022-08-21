namespace JwtExample.Consumers.Desktop.Domain.Commands.Products;

public sealed record CreateProductCommand : IRequest
{
	public Product? Product { get; }

	public CreateProductCommand(Product entity) => Product = entity;

	public CreateProductCommand() { }
}