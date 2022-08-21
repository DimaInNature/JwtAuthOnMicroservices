namespace JwtExample.Microservices.AuthService.Domain.Core.Models.Requests;

public sealed record LoginAuthenticationRequest(string Username, string Password);