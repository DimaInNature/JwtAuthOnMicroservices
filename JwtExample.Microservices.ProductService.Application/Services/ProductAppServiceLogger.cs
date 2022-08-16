namespace JwtExample.Microservices.ProductService.Application.Services;

public class ProductAppServiceLogger : IProductAppService
{
    private readonly IProductAppService _productAppService;

    private readonly ILogger<ProductAppServiceLogger> _logger;

    public ProductAppServiceLogger(
        IProductAppService productAppService,
        ILogger<ProductAppServiceLogger> logger) =>
        (_productAppService, _logger) = (productAppService, logger);

    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        var products = Enumerable.Empty<ProductEntity>();

        try
        {
            products = await _productAppService.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }

        return products;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync(
        Func<ProductEntity, bool> predicate)
    {
        var products = Enumerable.Empty<ProductEntity>();

        try
        {
            products = await _productAppService.GetAllAsync(predicate);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }

        return products;
    }

    public async Task<ProductEntity?> GetAsync(Guid id)
    {
        ProductEntity? product = default;

        try
        {
            product = await _productAppService.GetAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }

        return product;
    }

    public async Task<ProductEntity?> GetAsync(
        Func<ProductEntity, bool> predicate)
    {
        ProductEntity? product = default;

        try
        {
            product = await _productAppService.GetAsync(predicate);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }

        return product;
    }

    public async Task CreateAsync(ProductEntity entity)
    {
        try
        {
            await _productAppService.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }

    public async Task UpdateAsync(ProductEntity entity)
    {
        try
        {
            await _productAppService.UpdateAsync(entity);
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
            await _productAppService.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }
}