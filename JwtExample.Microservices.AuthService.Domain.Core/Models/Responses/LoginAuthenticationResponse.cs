namespace JwtExample.Microservices.AuthService.Domain.Core.Models.Responses;

public record LoginAuthenticationResponse
{
    public string? SecurityToken { get; set; }

    public UserEntity? User { get; set; }

    public int? ExpiredIn { get; set; }

    public LoginAuthenticationResponse(UserEntity user, string token, int expired) =>
        (User, SecurityToken, ExpiredIn) = (user, token, expired);

    public LoginAuthenticationResponse() { }

    public void Deconstruct(
        out string? securityToken,
        out UserEntity? user) =>
        (securityToken, user) = (SecurityToken, User);
}