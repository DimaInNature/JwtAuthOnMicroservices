namespace JwtExample.Shared.Authentication.Models;

public class UserAccount
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public UserAccount(
        string username,
        string password,
        string role) =>
        (Username, Password, Role) = (username, password, role);

    public UserAccount() { }
}