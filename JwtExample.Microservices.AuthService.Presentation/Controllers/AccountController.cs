namespace JwtExample.Microservices.AuthService.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class AccountController : ControllerBase
{
	private readonly JwtTokenHandler _jwtTokenHandler;

	public AccountController(JwtTokenHandler jwtTokenHandler)
	{
		_jwtTokenHandler = jwtTokenHandler;
	}

	[HttpPost]
	public ActionResult<AuthenticationResponse?> Authenticate(
		[FromBody] AuthenticationRequest authenticationRequest)
	{
		var response = _jwtTokenHandler.GenerateJwtToken(authenticationRequest);

		return response is null ? Unauthorized() : response;
	}
}