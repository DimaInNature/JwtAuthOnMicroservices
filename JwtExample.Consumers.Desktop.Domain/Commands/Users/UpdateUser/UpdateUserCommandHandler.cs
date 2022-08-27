namespace JwtExample.Consumers.Desktop.Domain.Commands.Users;

public sealed record UpdateUserCommandHandler
    : IRequestHandler<UpdateUserCommand>
{
    private readonly HttpClient _httpClient;

    private readonly ApplicationSettingsModel _applicationSettings;

    public UpdateUserCommandHandler(
        IHttpClientFactory httpClientFactory,
        IOptions<ApplicationSettingsModel> applicationSettings)
    {
        _httpClient = httpClientFactory.CreateClient(name: "BaseHttpClient");

        _applicationSettings = applicationSettings.Value;
    }

    public async Task<Unit> Handle(
        UpdateUserCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(
            argument: request.User,
            paramName: nameof(request));

        _httpClient.DefaultRequestHeaders.Authorization = new(
            scheme: "Bearer",
            parameter: request.Token);

        using var response = await _httpClient.PutAsync(
            requestUri: _applicationSettings.Routes.Users.UpdateUserRoute,
            content: new StringContent(
                content: JsonConvert.SerializeObject(value: request.User),
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken);

        response.EnsureSuccessStatusCode();

        return default;
    }
}