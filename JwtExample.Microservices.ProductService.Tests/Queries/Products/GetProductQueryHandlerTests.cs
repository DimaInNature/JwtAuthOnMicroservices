namespace JwtExample.Microservices.ProductService.Tests.Queries.Products;

public class GetProductQueryHandlerTests
{
	private readonly Mock<IGenericRepository<ProductEntity>> _repository;

	public GetProductQueryHandlerTests() =>
		_repository = MockRepositories.GetProductRepository();

	[Fact]
	public async Task GetProductTest()
	{
		// Arrange
		Guid guid = new(g: "9E678C05-D138-467D-80C6-669211903E89");

		GetProductQueryHandler handler = new(repository: _repository.Object);

		// Act
		var result = await handler.Handle(
			request: new(predicate: product => product.Id.Equals(g: guid)),
			token: default);

		// Assert
		result.Should().NotBeNull();

		result?.Id.Should().Be(expected: guid);
	}
}