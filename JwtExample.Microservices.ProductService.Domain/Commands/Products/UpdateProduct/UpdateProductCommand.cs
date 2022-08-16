namespace JwtExample.Microservices.ProductService.Domain.Commands.Products;

public sealed record class UpdateProductCommand : IRequest
{
    public ProductEntity? Product { get; }

    public UpdateProductCommand(ProductEntity entity) => Product = entity;

    public UpdateProductCommand() { }
}