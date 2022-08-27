namespace JwtExample.Consumers.Desktop.Domain.Queries.Products;

public sealed record GetProductByIdQueryHandler
    : IRequestHandler<GetProductByIdQuery, Product?>
{
    private readonly HttpClient _httpClient;

    private readonly ApplicationSettingsModel _applicationSettings;

    public GetProductByIdQueryHandler(
        IHttpClientFactory httpClientFactory,
        IOptions<ApplicationSettingsModel> applicationSettings)
    {
        _httpClient = httpClientFactory.CreateClient(name: "BaseHttpClient");

        _applicationSettings = applicationSettings.Value;
    }

    public async Task<Product?> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new(
             scheme: "Bearer",
             parameter: request.Token);

        var response = await _httpClient.GetAsync(
            requestUri: _applicationSettings.Routes.Products.GetProductByIdRoute,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject(value: apiResponse) as Product;
    }
}