namespace PjjDotnetWebApiCleanArch.Application.DTOs;

public class AsetGroupByKategori
{
    public string? KategoriName { get; set; }
    public List<AsetDto>? Assets { get; set; }
    public long TotalNilaiAset { get; set; }
}

