namespace JwtExample.Microservices.ProductService.Presentation.Controllers;

[Produces(contentType: "application/json")]
[ApiController]
[Route(template: "[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductAppService _productService;

    public ProductController(
        IProductAppService productService) =>
        _productService = productService;

    /// <summary>
    /// Get products.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Products
    ///
    /// </remarks>
    /// <returns>Return all products.</returns>
    /// <response code="200">Products list.</response>
    [Tags(tags: "Get")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<ProductEntity>>> GetList()
    {
        var result = await _productService.GetAllAsync();

        return result.Any() is false ? NotFound() : Ok(value: result);
    }

    /// <summary>
    /// Get product by Id.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     GET /Products/Guid
    ///
    /// </remarks>
    /// <param name="id">Id.</param>
    /// <returns>Product.</returns>
    /// <response code="200">Product.</response>
    /// <response code="404">If the product was not found.</response>
    [Tags(tags: "Get")]
    [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
    [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
    [HttpGet(template: "{id}")]
    [Authorize]
    public async Task<ActionResult<ProductEntity>> Get(Guid id)
    {
        var result = await _productService.GetAsync(id);

        return result is not null ? Ok(value: result) : NotFound();
    }

    /// <summary>
    /// Create product.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     POST /Products
    ///     {
    ///         "name": "product",
    ///         "description": "desc"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Created.</response>
    [Tags(tags: "Post")]
    [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
    [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ProductEntity>> Create(
        [FromBody] ProductEntity product)
    {
        if (product is not null)
            await _productService.CreateAsync(entity: product);

        return Ok();
    }

    /// <summary>
    /// Update product.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     PUT /Products
    ///     {
    ///         "id": Guid,
    ///         "name": "product",
    ///         "description": "desc"
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
        [FromBody] ProductEntity product)
    {
        if (product is not null)
            await _productService.UpdateAsync(entity: product);

        return NoContent();
    }

    /// <summary>
    /// Delete product.
    /// </summary>
    /// <remarks>
    /// Request example:
    ///
    ///     DELETE /Products/Guid
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
        await _productService.DeleteAsync(id);

        return NoContent();
    }
}