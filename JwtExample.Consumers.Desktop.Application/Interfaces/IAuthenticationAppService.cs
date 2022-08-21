namespace JwtExample.Consumers.Desktop.Application.Interfaces;

public interface IAuthenticationAppService
{
    public Task<LoginAuthenticationResponse?> AuthorizeAsync(LoginAuthenticationRequest request);
}