namespace JwtExample.Consumers.Desktop.Domain.Queries.Products;

public sealed record GetProductListQueryHandler
    : IRequestHandler<GetProductListQuery, IEnumerable<Product>>
{
    private readonly HttpClient _httpClient;

    private readonly ApplicationSettingsModel _applicationSettings;

    public GetProductListQueryHandler(
        HttpClient httpClient,
        IOptions<ApplicationSettingsModel> applicationSettings)
    {
        _httpClient = httpClient;

        _applicationSettings = applicationSettings.Value;
    }

    public async Task<IEnumerable<Product>> Handle(
        GetProductListQuery request,
        CancellationToken cancellationToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new(
            scheme: "Bearer",
            parameter: request.Token);

        var response = await _httpClient.GetAsync(
            requestUri: _applicationSettings.Routes.Products.GetProductListRoute,
            cancellationToken);

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject<IEnumerable<Product>>(value: apiResponse) ?? Enumerable.Empty<Product>();
    }
}