﻿namespace JwtExample.Consumers.Desktop.Application.Interfaces;

public interface IUserAppService
{
    public Task<User?> GetAsync(Guid id);

    public Task<IEnumerable<User>> GetAllAsync();

    public Task<User?> CreateAsync(User entity);

    public Task UpdateAsync(User entity);

    public Task DeleteAsync(Guid id);
}