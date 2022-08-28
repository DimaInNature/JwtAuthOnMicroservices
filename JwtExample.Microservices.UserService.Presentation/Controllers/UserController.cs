using JwtExample.Microservices.UserService.Persistence.Entities;

namespace JwtExample.Microservices.UserService.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserAppService _userService;

    public UserController(
        IUserAppService userService) =>
        _userService = userService;

    /// <summary>
    /// Get users.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /User
    ///
    /// </remarks>
    /// <returns>Return all users.</returns>
    /// <response code="200">Users list.</response>
    [Tags(tags: "Get")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<UserEntity>>> GetList()
    {
        var result = await _userService.GetAllAsync();

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get user by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /User/Guid
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>User.</returns>
    /// <response code="200">User.</response>
    /// <response code="404">If the user was not found.</response>
    [Tags(tags: "Get")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    [Authorize]
    public async Task<ActionResult<UserEntity>> Get(Guid id)
    {
        var result = await _userService.GetAsync(id);

        return result is not null ? Ok(value: result) : NotFound();
    }

    /// <summary>
    /// Create user.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /User
    ///     {
    ///         "username": "client",
    ///         "password": "root",
    ///         "role": "Admin"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Post")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<UserEntity>> Create(
        [FromBody] UserEntity user)
    {
        if (user is not null)
            await _userService.CreateAsync(entity: user);

        return Ok();
    }

    /// <summary>
    /// Update user.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /User
    ///     {
    ///         "id": Guid,
    ///         "username": "client",
    ///         "password": "root",
    ///         "role": "Admin"
    ///     }
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully modified.</response>
    [Tags(tags: "Put")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPut]
    [Authorize]
    public async Task<ActionResult> Update(
        [FromBody] UserEntity user)
    {
        if (user is not null)
            await _userService.UpdateAsync(entity: user);

        return NoContent();
    }

    /// <summary>
    /// Delete user.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /User/Guid
    ///
    /// </remarks>
    /// <response code="204">The object has been successfully deleted.</response>
    [Tags(tags: "Delete")]
    [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpDelete(template: "{id}")]
    [Authorize]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _userService.DeleteAsync(id);

        return NoContent();
    }
}