namespace JwtExample.Consumers.Desktop.Domain.Queries.Products;

public sealed record GetProductByIdQueryHandler
    : IRequestHandler<GetProductByIdQuery, Product?>
{
    private readonly HttpClient _httpClient;

    public GetProductByIdQueryHandler(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<Product?> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        if (request.Id == Guid.Empty) return default;

        return default;
    }
}