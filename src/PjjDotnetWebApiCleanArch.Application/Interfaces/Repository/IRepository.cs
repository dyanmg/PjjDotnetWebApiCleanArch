namespace PjjDotnetWebApiCleanArch.Application.Interfaces.Repository;

public interface IRepository<T> where T : class
{
    public Task<List<T>> GetAllAsync();
    public Task<T?> GetByIdAsync(Guid id);
}
