using PjjDotnetWebApiCleanArch.Domain.Entities;

namespace PjjDotnetWebApiCleanArch.Application.DTOs;

public class AsetGroupByKategori
{
    public string? KategoriName { get; set; }
    public List<Aset>? Assets { get; set; }
    public long TotalNilaiAset { get; set; }
}

public class AsetDtoGroupByKategori
{
    public string? KategoriName { get; set; }
    public List<AsetDto>? Assets { get; set; }
    public long TotalNilaiAset { get; set; }
}
