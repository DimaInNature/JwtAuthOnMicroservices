namespace JwtExample.Microservices.AuthService.Domain.Core.Models;

public class User
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public User(
        string username,
        string password,
        string role) : this(username, password) =>
        Role = role;

    public User(string username, string password) =>
        (Username, Password) = (username, password);

    public User() { }
}