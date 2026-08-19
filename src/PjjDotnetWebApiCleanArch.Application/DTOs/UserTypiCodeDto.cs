namespace PjjDotnetWebApiCleanArch.Application.DTOs;

public class UserTypiCodeDto
{
    public required string Id { get; set; }
    public required string Nama { get; set; }
    public string? Email { get; set; }
    public string? Telepon { get; set; }
}