namespace JwtExample.Consumers.Desktop.Domain.Core.Models.Requests;

public sealed record LoginAuthenticationRequest(string Username, string Password);