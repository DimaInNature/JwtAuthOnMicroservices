namespace JwtExample.Consumers.Desktop.Domain.Core.Models.Configuration.Routes;

public class RoutesSettingsModel
{
    public string GatewayRoute { get; set; } = string.Empty;

    public string AuthenticationRoute { get; set; } = string.Empty;

    public ProductRoutesSettingsModel Products { get; set; } = new();

    public UserRoutesSettingsModel Users { get; set; } = new();
}