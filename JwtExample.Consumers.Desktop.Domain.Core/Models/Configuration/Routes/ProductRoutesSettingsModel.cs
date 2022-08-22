namespace JwtExample.Consumers.Desktop.Domain.Core.Models.Configuration.Routes;

public class ProductRoutesSettingsModel
{
    public string CreateProductRoute { get; set; } = string.Empty;

    public string UpdateProductRoute { get; set; } = string.Empty;

    public string DeleteProductRoute { get; set; } = string.Empty;

    public string GetProductListRoute { get; set; } = string.Empty;

    public string GetProductByIdRoute { get; set; } = string.Empty;

    public string DeleteProduct(Guid id) =>
       string.Format(format: DeleteProductRoute, arg0: id);

    public string GetProductById(Guid id) =>
        string.Format(format: GetProductByIdRoute, arg0: id);
}