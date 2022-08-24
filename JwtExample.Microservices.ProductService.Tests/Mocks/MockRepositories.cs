namespace JwtExample.Microservices.ProductService.Tests.Mocks;

public static class MockRepositories
{
    public static Mock<IGenericRepository<ProductEntity>> GetProductRepository()
    {
        List<ProductEntity> products = new()
        {
            new() { Id = new Guid(g: "9E678C05-D138-467D-80C6-669211903E89"), Name = "Name1", Description = "Desc1" },
            new() { Id = new Guid(g: "181F935F-C370-4C07-8167-62CFDD938603"), Name = "Name2", Description = "Desc2" },
            new() { Id = new Guid(g: "0FB76030-40FA-4453-A712-FBEEB33EEACA"), Name = "Name3", Description = "Desc3" }
        };

        Mock<IGenericRepository<ProductEntity>> mockRepository = new();

        mockRepository.Setup(expression: behaviour => behaviour
            .GetFirstOrDefault(It.IsAny<Func<ProductEntity, bool>>()))
            .Returns<Func<ProductEntity, bool>>(valueFunction: predicate =>
                products.FirstOrDefault(predicate));

        return mockRepository;
    }
}