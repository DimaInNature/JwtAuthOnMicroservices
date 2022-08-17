namespace JwtExample.Shared.Authentication.Handlers;

public class JwtTokenHandler
{
    public const string KEY = "DontUseItInProduction";

    public const int TIME = 20;

    private readonly List<UserAccount> _userAccountList;

    public JwtTokenHandler()
    {
        _userAccountList = new()
        {
            new("Admin", "Root", "Admin"),
            new("User", "Root", "User")
        };
    }

    public AuthenticationResponse? GenerateJwtToken(
        AuthenticationRequest authenticationRequest)
    {
        if (string.IsNullOrWhiteSpace(value: authenticationRequest.Username) ||
            string.IsNullOrWhiteSpace(value: authenticationRequest.Password))
            return default;

        UserAccount? userAccount = _userAccountList.FirstOrDefault(x =>
            x.Username == authenticationRequest.Username &&
            x.Password == authenticationRequest.Password);

        if (userAccount is null) return default;

        DateTime tokenExpiryTimeStamp = DateTime.Now.AddMinutes(value: TIME);

        byte[] tokenKey = Encoding.ASCII.GetBytes(s: KEY);

        ClaimsIdentity ClaimsIdentity = new(claims: new List<Claim>()
        {
            new(type: JwtRegisteredClaimNames.Name, value: authenticationRequest.Username),
            new(type: ClaimTypes.Role, value: userAccount.Role)
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

        return new(username: userAccount.Username, jwtToken: token,
            expiredIn: (int)tokenExpiryTimeStamp.Subtract(value: DateTime.Now).TotalSeconds);
    }
}