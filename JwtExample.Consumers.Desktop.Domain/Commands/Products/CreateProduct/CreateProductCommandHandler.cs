namespace JwtExample.Consumers.Desktop.Domain.Commands.Products;

public sealed record CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, Product?>
{
    private readonly HttpClient _httpClient;

    private readonly ApplicationSettingsModel _applicationSettings;

    public CreateProductCommandHandler(
        IHttpClientFactory httpClientFactory,
        IOptions<ApplicationSettingsModel> applicationSettings)
    {
        _applicationSettings = applicationSettings.Value;

        _httpClient = httpClientFactory.CreateClient(name: "BaseHttpClient");
    }

    public async Task<Product?> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(
            argument: request.Product,
            paramName: nameof(request));

        _httpClient.DefaultRequestHeaders.Authorization = new(
            scheme: "Bearer",
            parameter: request.Token);

        using var response = await _httpClient.PostAsync(
            requestUri: _applicationSettings.Routes.Products.CreateProductRoute,
            content: new StringContent(
                content: JsonConvert.SerializeObject(value: request.Product),
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken);

        response.EnsureSuccessStatusCode();

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject(value: apiResponse) as Product;
    }
}