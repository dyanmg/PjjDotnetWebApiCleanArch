namespace PjjDotnetWebApiCleanArch.Application.Interfaces;

public interface IUnitOfWorks
{
    public void SaveChanges();
    public Task SaveChangesAsync();
}