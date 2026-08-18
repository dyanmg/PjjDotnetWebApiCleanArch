using PjjDotnetWebApiCleanArch.Domain.Common;

namespace PjjDotnetWebApiCleanArch.Domain.Entities;

public class Aset : BaseModel
{
    public string Nama { get; set; } = string.Empty;
    public DateOnly TanggalPerolehan { get; set; }
    public Guid KategoriId { get; set; }
    public int Nilai { get; set; }
    public string? FotoPath { get; set; }

    public Kategori? Kategori{ get; set; }
}
