namespace JwtExample.Consumers.Desktop.Domain.Commands.Products;

public sealed record UpdateProductCommand
    : BaseAuthorizedFeature, IRequest
{
    public Product? Product { get; }

    public UpdateProductCommand(Product entity, string token) =>
        (Product, Token) = (entity, token);

    public UpdateProductCommand() { }
}