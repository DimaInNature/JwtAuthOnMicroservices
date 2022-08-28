namespace JwtExample.Microservices.UserService.Infra.IoC.MediatR.Profiles;

public static class UserMediatRProfile
{
    public static void AddUserMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        services.AddScoped<IRequest<Unit>, CreateUserCommand>();
        services.AddScoped<IRequestHandler<CreateUserCommand, Unit>, CreateUserCommandHandler>();

        services.AddScoped<IRequest<Unit>, UpdateUserCommand>();
        services.AddScoped<IRequestHandler<UpdateUserCommand, Unit>, UpdateUserCommandHandler>();

        services.AddScoped<IRequest<Unit>, DeleteUserCommand>();
        services.AddScoped<IRequestHandler<DeleteUserCommand, Unit>, DeleteUserCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<UserEntity?>, GetUserQuery>();
        services.AddScoped<IRequestHandler<GetUserQuery, UserEntity?>, GetUserQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<UserEntity>>, GetUsersListQuery>();
        services.AddScoped<IRequestHandler<GetUsersListQuery, IEnumerable<UserEntity>>, GetUsersListQueryHandler>();

        #endregion
    }
}