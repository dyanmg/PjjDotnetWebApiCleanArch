namespace PjjDotnetWebApiCleanArch.Infrastructure.Integrations.TypiCode.Models;

internal class UserTypiCode
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
}
