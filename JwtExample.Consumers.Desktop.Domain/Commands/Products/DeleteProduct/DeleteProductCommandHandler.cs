namespace JwtExample.Consumers.Desktop.Domain.Commands.Products;

public sealed record DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand>
{
    private readonly HttpClient _httpClient;

    public DeleteProductCommandHandler(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<Unit> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty) return default;

        return default;
    }
}