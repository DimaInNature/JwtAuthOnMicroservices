namespace JwtExample.Shared.Authentication.Models;

public class AuthenticationResponse
{
    public string? Username { get; set; }

    public string? JwtToken { get; set; }

    public int? ExpiredIn { get; set; }

    public AuthenticationResponse(
        string username,
        string jwtToken,
        int expiredIn) =>
        (Username, JwtToken, ExpiredIn) = (username, jwtToken, expiredIn);

    public AuthenticationResponse() { }
}