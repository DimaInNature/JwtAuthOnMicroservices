namespace JwtExample.Consumers.Desktop.Domain.Queries.Users;

public sealed record GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, User?>
{
    private readonly HttpClient _httpClient;

    private readonly ApplicationSettingsModel _applicationSettings;

    public GetUserByIdQueryHandler(
        IHttpClientFactory httpClientFactory,
        IOptions<ApplicationSettingsModel> applicationSettings)
    {
        _httpClient = httpClientFactory.CreateClient(name: "BaseHttpClient");

        _applicationSettings = applicationSettings.Value;
    }

    public async Task<User?> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new(
           scheme: "Bearer",
           parameter: request.Token);

        var response = await _httpClient.GetAsync(
            requestUri: _applicationSettings.Routes.Users.GetUserByIdRoute,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject(value: apiResponse) as User;
    }
}