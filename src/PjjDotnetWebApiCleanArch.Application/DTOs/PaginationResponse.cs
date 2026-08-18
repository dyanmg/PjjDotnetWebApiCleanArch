namespace PjjDotnetWebApiCleanArch.Application.DTOs;

public class PaginationResponse<T>
{
    public int Total { get; set; }
    public List<T> Items { get; set; }
}
