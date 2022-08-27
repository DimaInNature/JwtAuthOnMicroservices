namespace JwtExample.Consumers.Desktop.Domain.Commands.Products;

public sealed record DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand>
{
    private readonly HttpClient _httpClient;

    private readonly ApplicationSettingsModel _applicationSettings;

    public DeleteProductCommandHandler(
        IHttpClientFactory httpClientFactory,
        IOptions<ApplicationSettingsModel> applicationSettings)
    {
        _httpClient = httpClientFactory.CreateClient(name: "BaseHttpClient");

        _applicationSettings = applicationSettings.Value;
    }

    public async Task<Unit> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Id.Equals(g: Guid.Empty))
        {
            return default;
        }

        _httpClient.DefaultRequestHeaders.Authorization = new(
            scheme: "Bearer",
            parameter: request.Token);

        using var response = await _httpClient.DeleteAsync(
            requestUri: _applicationSettings.Routes.Products.DeleteProduct(id: request.Id),
            cancellationToken);

        response.EnsureSuccessStatusCode();

        return default;
    }
}