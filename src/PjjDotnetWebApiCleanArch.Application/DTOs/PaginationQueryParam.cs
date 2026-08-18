namespace PjjDotnetWebApiCleanArch.Application.DTOs;

public class PaginationQueryParam
{
    public int Limit { get; set; } = 5;
    public int Offset { get; set; } = 0;
    public bool IncludeDeleted { get; set; } = false;
}
