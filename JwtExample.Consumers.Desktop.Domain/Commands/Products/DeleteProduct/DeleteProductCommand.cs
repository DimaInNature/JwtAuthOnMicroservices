namespace JwtExample.Consumers.Desktop.Domain.Commands.Products;

public sealed record DeleteProductCommand
    : BaseAuthorizedFeature, IRequest
{
    public Guid Id { get; }

    public DeleteProductCommand(Guid id, string token) =>
        (Id, Token) = (id, token);

    public DeleteProductCommand() { }
}