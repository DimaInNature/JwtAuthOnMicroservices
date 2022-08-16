namespace JwtExample.Microservices.ProductService.Infra.IoC.MediatR.Profiles;

public static class ProductMediatRProfile
{
    public static void AddProductMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        services.AddScoped<IRequest<Unit>, CreateProductCommand>();
        services.AddScoped<IRequestHandler<CreateProductCommand, Unit>, CreateProductCommandHandler>();

        services.AddScoped<IRequest<Unit>, UpdateProductCommand>();
        services.AddScoped<IRequestHandler<UpdateProductCommand, Unit>, UpdateProductCommandHandler>();

        services.AddScoped<IRequest<Unit>, DeleteProductCommand>();
        services.AddScoped<IRequestHandler<DeleteProductCommand, Unit>, DeleteProductCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<ProductEntity?>, GetProductQuery>();
        services.AddScoped<IRequestHandler<GetProductQuery, ProductEntity?>, GetProductQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<ProductEntity>>, GetProductsListQuery>();
        services.AddScoped<IRequestHandler<GetProductsListQuery, IEnumerable<ProductEntity>>, GetProductsListQueryHandler>();

        #endregion
    }
}