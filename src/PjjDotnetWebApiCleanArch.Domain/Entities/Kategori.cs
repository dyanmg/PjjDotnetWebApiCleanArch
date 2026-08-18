using PjjDotnetWebApiCleanArch.Domain.Common;

namespace PjjDotnetWebApiCleanArch.Domain.Entities;

public class Kategori : BaseModel
{
    public string Nama { get; set; } = string.Empty;

    public List<Aset> Aset { get; set; } = [];
}
