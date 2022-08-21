namespace JwtExample.Consumers.Desktop.Domain.Commands.Products;

public sealed record DeleteProductCommand : IRequest
{
    public Guid Id { get; }

    public DeleteProductCommand(Guid id) => Id = id;

    public DeleteProductCommand() { }
}