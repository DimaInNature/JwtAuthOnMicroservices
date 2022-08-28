namespace JwtExample.Microservices.UserService.Application.Services;

public class UserAppServiceLogger : IUserAppService
{
    private readonly IUserAppService _userService;

    private readonly ILogger<UserAppServiceLogger> _logger;

    public UserAppServiceLogger(
        IUserAppService userService,
        ILogger<UserAppServiceLogger> logger) =>
        (_userService, _logger) = (userService, logger);

    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        var products = Enumerable.Empty<UserEntity>();

        try
        {
            products = await _userService.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }

        return products;
    }

    public async Task<IEnumerable<UserEntity>> GetAllAsync(
        Func<UserEntity, bool> predicate)
    {
        var products = Enumerable.Empty<UserEntity>();

        try
        {
            products = await _userService.GetAllAsync(predicate);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }

        return products;
    }

    public async Task<UserEntity?> GetAsync(Guid id)
    {
        UserEntity? product = default;

        try
        {
            product = await _userService.GetAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }

        return product;
    }

    public async Task<UserEntity?> GetAsync(
        Func<UserEntity, bool> predicate)
    {
        UserEntity? product = default;

        try
        {
            product = await _userService.GetAsync(predicate);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }

        return product;
    }

    public async Task CreateAsync(UserEntity entity)
    {
        try
        {
            await _userService.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }

    public async Task UpdateAsync(UserEntity entity)
    {
        try
        {
            await _userService.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            await _userService.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }
}