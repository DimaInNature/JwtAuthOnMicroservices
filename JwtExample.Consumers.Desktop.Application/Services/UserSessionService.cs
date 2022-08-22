namespace JwtExample.Consumers.Desktop.Application.Services;

public class UserSessionService
{
    public string? JwtToken { get; private set; }

    public bool IsActive { get; private set; } = false;

    public User? ActiveUser
    {
        get => _activeUser;
        private set
        {
            ArgumentNullException.ThrowIfNull(
                argument: value,
                paramName: nameof(ActiveUser));

            _activeUser = value;
        }
    }
    private User? _activeUser;

    public void StartSession(LoginAuthenticationResponse authResponse)
    {
        if (authResponse is
        { User: default(User) } or
        { SecurityToken: default(string) or "" })
            throw new ArgumentNullException(paramName: nameof(authResponse));

        if (IsActive) return;

        (JwtToken, ActiveUser) = authResponse;

        IsActive = true;
    }

    public void EndSession()
    {
        if (IsActive is false) return;

        _activeUser = default;

        JwtToken = default;

        IsActive = false;
    }
}