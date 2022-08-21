namespace JwtExample.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

public static class ProductMediatRProfile
{
    public static void AddProductMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Queries

        services.AddScoped<IRequest<IEnumerable<Product>>, GetProductListQuery>();
        services.AddScoped<IRequestHandler<GetProductListQuery, IEnumerable<Product>>, GetProductListQueryHandler>();

        services.AddScoped<IRequest<Product?>, GetProductByIdQuery>();
        services.AddScoped<IRequestHandler<GetProductByIdQuery, Product?>, GetProductByIdQueryHandler>();

        #endregion

        #region Commands

        services.AddScoped<IRequest<Unit>, CreateProductCommand>();
        services.AddScoped<IRequestHandler<CreateProductCommand, Unit>, CreateProductCommandHandler>();

        services.AddScoped<IRequest<Unit>, UpdateProductCommand>();
        services.AddScoped<IRequestHandler<UpdateProductCommand, Unit>, UpdateProductCommandHandler>();

        services.AddScoped<IRequest<Unit>, DeleteProductCommand>();
        services.AddScoped<IRequestHandler<DeleteProductCommand, Unit>, DeleteProductCommandHandler>();

        #endregion
    }
}