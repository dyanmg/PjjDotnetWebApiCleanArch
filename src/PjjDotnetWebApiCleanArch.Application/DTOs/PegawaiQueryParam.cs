namespace PjjDotnetWebApiCleanArch.Application.DTOs;

public class PegawaiQueryParam : PaginationQueryParam
{
    public string? Nama { get; set; }
    public string? Nip { get; set; }
}
