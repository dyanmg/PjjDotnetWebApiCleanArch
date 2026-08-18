namespace PjjDotnetWebApiCleanArch.Application.DTOs;

public class AssignUserRoleDto
{
    public required string Email { get; set; }
    public required string RoleName { get; set; }
}