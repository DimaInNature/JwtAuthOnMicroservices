namespace JwtExample.Consumers.Desktop.Domain.Commands.Products;

public sealed record UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand>
{
    private readonly HttpClient _httpClient;

    public UpdateProductCommandHandler(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<Unit> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Product is null) return default;

        return default;
    }
}