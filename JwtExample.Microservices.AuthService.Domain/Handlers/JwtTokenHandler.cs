namespace JwtExample.Microservices.AuthService.Domain.Handlers;

public class JwtTokenHandler
{
    private readonly List<User> _usersList;

    private readonly ApplicationSettingsModel _applicationSettings;

    public JwtTokenHandler(IOptions<ApplicationSettingsModel> applicationSettings)
    {
        _applicationSettings = applicationSettings.Value;

        _usersList = new()
        {
            new("Admin", "Root", "Admin"),
            new("User", "Root", "User")
        };
    }
    public LoginAuthenticationResponse? GenerateJwtToken(
        LoginAuthenticationRequest request)
    {
        if (string.IsNullOrWhiteSpace(value: request.Username) |
            string.IsNullOrWhiteSpace(value: request.Password))
            return default;

        User? user = _usersList.FirstOrDefault(user =>
            user.Username == request.Username &&
            user.Password == request.Password);

        if (user is null) return default;

        DateTime tokenExpiryTimeStamp = DateTime.Now.AddMinutes(value: _applicationSettings.Authentication.ExpiryTimeInMinutes);

        byte[] tokenKey = Encoding.ASCII.GetBytes(s: _applicationSettings.Authentication.SecurityKey);

        ClaimsIdentity ClaimsIdentity = new(claims: new List<Claim>()
        {
            new(type: JwtRegisteredClaimNames.Name, value: request.Username),
            new(type: "Role", value: user.Role)
        });

        SigningCredentials signingCredentials = new(
            key: new SymmetricSecurityKey(key: tokenKey),
            algorithm: SecurityAlgorithms.HmacSha256Signature);

        SecurityTokenDescriptor securityTokenDescriptor = new()
        {
            Subject = ClaimsIdentity,
            Expires = tokenExpiryTimeStamp,
            SigningCredentials = signingCredentials
        };

        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

        SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(
            tokenDescriptor: securityTokenDescriptor);

        string token = jwtSecurityTokenHandler.WriteToken(token: securityToken);

        int expiredInSeconds = (int)tokenExpiryTimeStamp.Subtract(value: DateTime.Now).TotalSeconds;

        return new(user, token, expired: expiredInSeconds);
    }
}