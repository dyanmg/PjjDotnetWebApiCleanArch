using System.Net.Http.Json;
using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Service.ExternalClient;
using PjjDotnetWebApiCleanArch.Infrastructure.Integrations.TypiCode.Mappers;
using PjjDotnetWebApiCleanArch.Infrastructure.Integrations.TypiCode.Models;

namespace PjjDotnetWebApiCleanArch.Infrastructure.Integrations.TypiCode;

public class TypiCodeClient(HttpClient _httpClient) : ITypiCodeClient
{
    public async Task<UserTypiCodeDto?> GetUserByIdAsync(string id)
    {
        var response = await _httpClient.GetFromJsonAsync<UserTypiCode>($"users/{id}");

        return response?.MapUserToDto();
    }

    public async Task<List<UserTypiCodeDto>> GetUsersAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<UserTypiCode>>($"users");

        var users = response?.Select(TypiCodeMapper.MapUserToDto)?.ToList();

        return users ?? [];
    }

    public async Task<UserTypiCodeWithPostsDto?> GetUserWithPostsByIdAsync(string id)
    {
        var userResponse = await _httpClient.GetFromJsonAsync<UserTypiCode>($"users/{id}");

        if (userResponse == null)
        {
            return null;
        }

        var postsResponse = await _httpClient.GetFromJsonAsync<List<PostTypiCode>>($"users/{id}/posts");

        var result = (userResponse, postsResponse).MapToDto();

        return result;
    }
}
