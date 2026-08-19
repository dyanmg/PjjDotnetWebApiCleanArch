using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Infrastructure.Integrations.TypiCode.Models;

namespace PjjDotnetWebApiCleanArch.Infrastructure.Integrations.TypiCode.Mappers;

internal static class TypiCodeMapper
{
    public static UserTypiCodeDto MapUserToDto(this UserTypiCode user)
    {
        return new UserTypiCodeDto
        {
            Id = user.Id.ToString(),
            Nama = user.Name,
            Email = user.Email,
            Telepon = user.Phone
        };
    }

    public static UserTypiCodeWithPostsDto MapToDto(this (UserTypiCode user, List<PostTypiCode>? posts) data)
    {
        var (user, posts) = data;

        return new UserTypiCodeWithPostsDto
        {
            Id = user.Id.ToString(),
            Nama = user.Name,
            Email = user.Email,
            Telepon = user.Phone,
            Posts = posts?.Select(post => new PostTypiCodeDto
            {
                Judul = post.Title,
                Isi = post.Body
            })?.ToList() ?? []
        };
    }
}