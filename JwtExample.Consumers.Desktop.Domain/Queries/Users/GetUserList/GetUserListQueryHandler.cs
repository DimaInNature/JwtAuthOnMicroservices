namespace JwtExample.Consumers.Desktop.Domain.Queries.Users;

public sealed record GetUserListQueryHandler
    : IRequestHandler<GetUserListQuery, IEnumerable<User>>
{
    private readonly HttpClient _httpClient;

    private readonly ApplicationSettingsModel _applicationSettings;

    public GetUserListQueryHandler(
        IHttpClientFactory httpClientFactory,
        IOptions<ApplicationSettingsModel> applicationSettings)
    {
        _httpClient = httpClientFactory.CreateClient(name: "BaseHttpClient");

        _applicationSettings = applicationSettings.Value;
    }

    public async Task<IEnumerable<User>> Handle(
        GetUserListQuery request,
        CancellationToken cancellationToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new(
           scheme: "Bearer",
           parameter: request.Token);

        var response = await _httpClient.GetAsync(
            requestUri: _applicationSettings.Routes.Users.GetUsersListRoute,
            cancellationToken);

        response.EnsureSuccessStatusCode();

        string apiResponse = await response.Content.ReadAsStringAsync(cancellationToken);

        return JsonConvert.DeserializeObject<IEnumerable<User>>(value: apiResponse) ?? Enumerable.Empty<User>();
    }
}