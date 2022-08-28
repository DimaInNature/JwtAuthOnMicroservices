namespace JwtExample.Microservices.UserService.Persistence.Entities;

public class UserEntity : IDatabaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public UserEntity(string username, string password) =>
        (Username, Password) = (username, password);

    public UserEntity(string username, string password, string role)
        : this(username, password) => Role = role;

    public UserEntity() { }

    public void Deconstruct(
        out Guid id,
        out string username,
        out string password,
        out string role) =>
        (id, username, password, role) = (Id, Username, Password, Role);
}