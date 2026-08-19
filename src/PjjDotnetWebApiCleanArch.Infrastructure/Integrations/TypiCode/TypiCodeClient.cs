using System.Net.Http.Json;
using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Service.ExternalClient;
using PjjDotnetWebApiCleanArch.Infrastructure.Integrations.TypiCode.Mappers;
using PjjDotnetWebApiCleanArch.Infrastructure.Integrations.TypiCode.Models;

namespace PjjDotnetWebApiCleanArch.Infrastructure.Integrations.TypiCode;

public class TypiCodeClient(HttpClient _httpClient) : ITypiCodeClient
{
    private const string BaseUrl = "https://jsonplaceholder.typicode.com";

    public async Task<UserTypiCodeDto?> GetUserByIdAsync(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<UserTypiCode>($"{BaseUrl}/users/{id}");

        return response?.MapToDto();
    }

    public async Task<List<UserTypiCodeDto>> GetUsersAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<UserTypiCode>>($"{BaseUrl}/users");

        var users = response?.Select(UserTypiCodeMapper.MapToDto)?.ToList();

        return users ?? [];
    }
}
