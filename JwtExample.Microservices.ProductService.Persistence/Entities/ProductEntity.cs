namespace JwtExample.Microservices.ProductService.Persistence.Entities;

public class ProductEntity : IDatabaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ProductEntity(string name, string description) =>
        (Name, Description) = (name, description);

    public ProductEntity() { }

    public void Deconstruct(
        out Guid id,
        out string name,
        out string description) =>
        (id, name, description) = (Id, Name, Description);
}