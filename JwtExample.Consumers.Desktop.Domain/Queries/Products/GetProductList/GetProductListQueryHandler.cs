namespace JwtExample.Consumers.Desktop.Domain.Queries.Products;

public sealed record GetProductListQueryHandler
    : IRequestHandler<GetProductListQuery, IEnumerable<Product>>
{
    private readonly HttpClient _httpClient;

    public GetProductListQueryHandler(HttpClient httpClient) =>
        _httpClient = httpClient;

    public Task<IEnumerable<Product>> Handle(
        GetProductListQuery request,
        CancellationToken cancellationToken)
    {
        return default;
    }
}