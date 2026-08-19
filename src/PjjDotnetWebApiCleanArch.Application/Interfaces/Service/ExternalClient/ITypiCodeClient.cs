using PjjDotnetWebApiCleanArch.Application.DTOs;

namespace PjjDotnetWebApiCleanArch.Application.Interfaces.Service.ExternalClient;

public interface ITypiCodeClient
{
    public Task<List<UserTypiCodeDto>> GetUsersAsync();
    public Task<UserTypiCodeDto?> GetUserByIdAsync(string id);
}