using Microsoft.AspNetCore.Identity;

namespace PjjDotnetWebApiCleanArch.Domain.Common;

public class BaseIdentityModel : IdentityUser
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? UpdateBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
