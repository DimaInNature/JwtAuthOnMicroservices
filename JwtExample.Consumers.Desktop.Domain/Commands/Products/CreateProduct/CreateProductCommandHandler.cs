namespace JwtExample.Consumers.Desktop.Domain.Commands.Products;

public sealed record CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand>
{
    private readonly HttpClient _httpClient;

    public CreateProductCommandHandler(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<Unit> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Product is null) return default;

        return default;
    }
}