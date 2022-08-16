namespace JwtExample.Microservices.ProductService.Domain.Commands.Products;

public sealed record class CreateProductCommand : IRequest
{
    public ProductEntity? Product { get; }

    public CreateProductCommand(ProductEntity entity) => Product = entity;

    public CreateProductCommand() { }
}