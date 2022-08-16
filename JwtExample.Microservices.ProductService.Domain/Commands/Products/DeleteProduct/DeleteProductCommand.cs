namespace JwtExample.Microservices.ProductService.Domain.Commands.Products;

public sealed record class DeleteProductCommand : IRequest
{
    public Guid Id { get; }

    public DeleteProductCommand(Guid id) => Id = id;

    public DeleteProductCommand() { }
}