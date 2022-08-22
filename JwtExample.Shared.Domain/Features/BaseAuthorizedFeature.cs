namespace JwtExample.Shared.Domain.Features;

public abstract record BaseAuthorizedFeature
{
    public string? Token { get; set; }
}