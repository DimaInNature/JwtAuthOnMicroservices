namespace JwtExample.Shared.Authentication.Models;

public class AuthenticationRequest
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public AuthenticationRequest(string username, string password) =>
        (Username, Password) = (username, password);

    public AuthenticationRequest() { }
}