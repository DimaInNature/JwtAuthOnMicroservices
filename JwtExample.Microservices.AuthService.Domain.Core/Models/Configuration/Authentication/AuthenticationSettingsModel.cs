namespace JwtExample.Microservices.AuthService.Domain.Core.Models.Configuration.Authentication;

public class AuthenticationSettingsModel
{
    public string SecurityKey { get; set; } = string.Empty;

    public double ExpiryTimeInMinutes { get; set; } = 0;
}