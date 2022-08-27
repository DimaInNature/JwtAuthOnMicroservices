namespace JwtExample.Consumers.Desktop.Domain.Commands.Users;

public sealed record DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand>
{
    private readonly HttpClient _httpClient;

    private readonly ApplicationSettingsModel _applicationSettings;

    public DeleteUserCommandHandler(
        IHttpClientFactory httpClientFactory,
        IOptions<ApplicationSettingsModel> applicationSettings)
    {
        _httpClient = httpClientFactory.CreateClient(name: "BaseHttpClient");

        _applicationSettings = applicationSettings.Value;
    }

    public async Task<Unit> Handle(
        DeleteUserCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Id.Equals(g: Guid.Empty))
        {
            return default;
        }

        var response = await _httpClient.DeleteAsync(
            requestUri: _applicationSettings.Routes.Users.DeleteUser(id: request.Id),
            cancellationToken);

        response.EnsureSuccessStatusCode();

        return default;
    }
}