namespace JwtExample.Consumers.Desktop.Domain.Commands.Users;

public sealed record CreateUserCommandHandler
    : IRequestHandler<CreateUserCommand, User?>
{
    private readonly HttpClient _httpClient;

    private readonly ApplicationSettingsModel _applicationSettings;

    public CreateUserCommandHandler(
        IHttpClientFactory httpClientFactory,
        IOptions<ApplicationSettingsModel> applicationSettings)
    {
        _httpClient = httpClientFactory.CreateClient(name: "BaseHttpClient");

        _applicationSettings = applicationSettings.Value;
    }

    public async Task<User?> Handle(
        CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(
            argument: request.User,
            paramName: nameof(request));

        using var response = await _httpClient.PostAsync(
            requestUri: _applicationSettings.Routes.Users.CreateUserRoute,
            content: new StringContent(
                content: JsonConvert.SerializeObject(value: request.User),
                encoding: Encoding.UTF8,
                mediaType: "application/json"),
            cancellationToken);

        response.EnsureSuccessStatusCode();

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject<User>(value: apiResponse);
    }
}