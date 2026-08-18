namespace PjjDotnetWebApiCleanArch.Application.DTOs;

public class AsetQueryParam : PaginationQueryParam
{
    /// <summary>
    /// Filter berdasarkan nama aset
    /// </summary>
    public string? Nama { get; set; }
    public string? Kategori { get; set; }
    /// <summary>
    /// Filter berdasarkan tahun perolehan
    /// </summary>
    public int? Tahun { get; set; }        
}
