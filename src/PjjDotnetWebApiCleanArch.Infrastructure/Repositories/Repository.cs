using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Repository;
using PjjDotnetWebApiCleanArch.Infrastructure.Persistence;

namespace PjjDotnetWebApiCleanArch.Infrastructure.Repositories;

internal class Repository<T>(AppDbContext _context) : IRepository<T> where T : class
{
    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>()
            .AsNoTracking()
            .FirstOrDefault(predicate);
    }

    public List<T> GetAll()
    {
        return [.. _context.Set<T>()];
    }

    public List<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return [.. _context.Set<T>()
            .AsNoTracking()
            .Where(predicate)];
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}