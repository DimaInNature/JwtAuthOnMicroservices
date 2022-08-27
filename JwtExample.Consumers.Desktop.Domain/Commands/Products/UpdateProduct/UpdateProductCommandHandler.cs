namespace JwtExample.Consumers.Desktop.Domain.Commands.Products;

public sealed record UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand>
{
    private readonly HttpClient _httpClient;

    private readonly ApplicationSettingsModel _applicationSettings;

    public UpdateProductCommandHandler(
        IHttpClientFactory httpClientFactory,
        IOptions<ApplicationSettingsModel> applicationSettings)
    {
        _httpClient = httpClientFactory.CreateClient(name: "BaseHttpClient");

        _applicationSettings = applicationSettings.Value;
    }

    public async Task<Unit> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(
            argument: request.Product,
            paramName: nameof(request));

        _httpClient.DefaultRequestHeaders.Authorization = new(
            scheme: "Bearer",
            parameter: request.Token);

        using var response = await _httpClient.PutAsync(
            requestUri: _applicationSettings.Routes.Products.UpdateProductRoute,
            content: new StringContent(
                content: JsonConvert.SerializeObject(value: request.Product),
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken);

        response.EnsureSuccessStatusCode();

        return default;
    }
}