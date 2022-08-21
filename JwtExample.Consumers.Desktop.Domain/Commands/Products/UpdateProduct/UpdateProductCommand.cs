namespace JwtExample.Consumers.Desktop.Domain.Commands.Products;

public sealed record UpdateProductCommand : IRequest
{
    public Product? Product { get; }

    public UpdateProductCommand(Product entity) => Product = entity;

    public UpdateProductCommand() { }
}