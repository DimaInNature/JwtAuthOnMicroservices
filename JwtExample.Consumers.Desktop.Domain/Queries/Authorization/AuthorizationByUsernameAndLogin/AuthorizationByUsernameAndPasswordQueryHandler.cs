namespace JwtExample.Consumers.Desktop.Domain.Queries.Authorization;

public record AuthorizationByUsernameAndPasswordQueryHandler
    : IRequestHandler<AuthorizationByUsernameAndPasswordQuery, LoginAuthenticationResponse?>
{
    private readonly HttpClient _httpClient;

    private readonly ApplicationSettingsModel _applicationSettings;

    public AuthorizationByUsernameAndPasswordQueryHandler(
        IOptions<ApplicationSettingsModel> applicationSettings,
        IHttpClientFactory httpClientFactory)
    {
        _applicationSettings = applicationSettings.Value;

        _httpClient = httpClientFactory.CreateClient(name: "BaseHttpClient");
    }

    public async Task<LoginAuthenticationResponse?> Handle(
        AuthorizationByUsernameAndPasswordQuery request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(
            argument: request.Request,
            paramName: nameof(request));

        using var response = await _httpClient.PostAsync(
            requestUri: _applicationSettings.Routes.AuthenticationRoute,
            content: new StringContent(
                content: JsonConvert.SerializeObject(value: request.Request),
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken);

        response.EnsureSuccessStatusCode();

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject<LoginAuthenticationResponse>(value: apiResponse);
    }
}