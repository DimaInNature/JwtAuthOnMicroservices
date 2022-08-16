namespace JwtExample.Microservices.ProductService.Domain.Commands.Products;

public sealed record class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand>
{
    private readonly IGenericRepository<ProductEntity> _repository;

    public UpdateProductCommandHandler(
        IGenericRepository<ProductEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        UpdateProductCommand request,
        CancellationToken token)
    {
        if (request.Product is null) return default;

        await _repository.UpdateAsync(entity: request.Product, token);

        return default;
    }
}