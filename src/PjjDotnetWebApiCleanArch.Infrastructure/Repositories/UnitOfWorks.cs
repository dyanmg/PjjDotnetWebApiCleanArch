using PjjDotnetWebApiCleanArch.Application.Interfaces;
using PjjDotnetWebApiCleanArch.Infrastructure.Persistence;

namespace PjjDotnetWebApiCleanArch.Infrastructure.Repositories;

public class UnitOfWorks(AppDbContext _context) : IUnitOfWorks
{
    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}