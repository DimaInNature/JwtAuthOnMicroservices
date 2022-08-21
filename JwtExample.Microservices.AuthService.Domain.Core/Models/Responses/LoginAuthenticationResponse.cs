namespace JwtExample.Microservices.AuthService.Domain.Core.Models.Responses;

public record LoginAuthenticationResponse
{
    public string? SecurityToken { get; set; }

    public User? User { get; set; }

    public int? ExpiredIn { get; set; }

    public LoginAuthenticationResponse(User user, string token, int expired) =>
        (User, SecurityToken, ExpiredIn) = (user, token, expired);

    public LoginAuthenticationResponse() { }

    public void Deconstruct(
        out string? securityToken,
        out User? user) =>
        (securityToken, user) = (SecurityToken, User);
}