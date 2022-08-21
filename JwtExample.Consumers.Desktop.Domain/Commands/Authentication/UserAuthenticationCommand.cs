namespace JwtExample.Consumers.Desktop.Domain.Commands.Authentication;

public sealed record UserAuthenticationCommand
    : IRequest<string?>
{
    public string? Username { get; }

    public string? Password { get; }

    public UserAuthenticationCommand(
        string username, string password) =>
        (Username, Password) = (username, password);

    public UserAuthenticationCommand() { }
}