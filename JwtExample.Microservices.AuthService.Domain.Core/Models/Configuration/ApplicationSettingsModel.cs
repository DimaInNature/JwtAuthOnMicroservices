namespace JwtExample.Microservices.AuthService.Domain.Core.Models.Configuration;

public class ApplicationSettingsModel
{
    public AuthenticationSettingsModel Authentication { get; set; } = new();
}