namespace JwtExample.Microservices.ProductService.Domain.Commands.Products;

public sealed record class DeleteProductCommandHandler
    : IRequestHandler<DeleteProductCommand>
{
    private readonly IGenericRepository<ProductEntity> _repository;

    public DeleteProductCommandHandler(
        IGenericRepository<ProductEntity> repository) =>
        _repository = repository;

    public async Task<Unit> Handle(
        DeleteProductCommand request,
        CancellationToken token)
    {
        if (request.Id == Guid.Empty) return default;

        await _repository.DeleteAsync(key: request.Id, token);

        return default;
    }
}