using System.Linq.Expressions;

namespace PjjDotnetWebApiCleanArch.Application.Interfaces.Repository;

public interface IRepository<T> where T : class
{
    public List<T> GetAll();
    public List<T> GetAll(Func<T, string?> orderByAsc, int skip, int take);
    public List<T> GetAll(Expression<Func<T, bool>> predicate);
    public List<T> GetAll(Expression<Func<T, bool>> predicate, Func<T, string?> orderByAsc, int skip, int take);
    public Task<List<T>> GetAllAsync();
    public Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    public T? Get(Expression<Func<T, bool>> predicate);
    public Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    public int Count();
    public int Count(Expression<Func<T, bool>> predicate);
    public void Create(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}
