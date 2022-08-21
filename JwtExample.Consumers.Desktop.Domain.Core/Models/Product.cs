namespace JwtExample.Consumers.Desktop.Domain.Core.Models;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Product(
        string name,
        string description) =>
        (Name, Description) = (name, description);

    public Product() { }

    public void Deconstruct(
        out Guid id,
        out string name,
        out string description) =>
        (id, name, description) = (Id, Name, Description);
}