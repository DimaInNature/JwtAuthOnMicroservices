namespace JwtExample.Consumers.Desktop.Domain.Core.Models.Configuration.Routes;

public class UserRoutesSettingsModel
{
    public string CreateUserRoute { get; set; } = string.Empty;

    public string UpdateUserRoute { get; set; } = string.Empty;

    public string DeleteUserRoute { get; set; } = string.Empty;

    public string GetUsersListRoute { get; set; } = string.Empty;

    public string GetUserByIdRoute { get; set; } = string.Empty;

    public string DeleteUser(Guid id) =>
       string.Format(format: DeleteUserRoute, arg0: id);

    public string GetUserById(Guid id) =>
        string.Format(format: GetUserByIdRoute, arg0: id);
}