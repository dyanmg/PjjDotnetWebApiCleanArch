using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Infrastructure.Integrations.TypiCode.Models;

namespace PjjDotnetWebApiCleanArch.Infrastructure.Integrations.TypiCode.Mappers;

internal static class UserTypiCodeMapper
{
    public static UserTypiCodeDto MapToDto(this UserTypiCode user)
    {
        return new UserTypiCodeDto
        {
            Id = user.Id.ToString(),
            Nama = user.Name,
            Email = user.Email,
            Telepon = user.Phone
        };
    }
}