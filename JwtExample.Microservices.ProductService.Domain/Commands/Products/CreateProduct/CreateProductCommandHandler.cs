namespace JwtExample.Microservices.ProductService.Domain.Commands.Products;

public sealed record class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand>
{
    private readonly IGenericRepository<ProductEntity> _repository;

    public CreateProductCommandHandler(
        IGenericRepository<ProductEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        CreateProductCommand request,
        CancellationToken token)
    {
        if (request.Product is null) return default;

        await _repository.CreateAsync(entity: request.Product, token);

        return default;
    }
}