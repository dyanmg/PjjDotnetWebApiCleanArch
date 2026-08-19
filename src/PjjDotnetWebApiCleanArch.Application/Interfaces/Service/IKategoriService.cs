using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Domain.Entities;

namespace PjjDotnetWebApiCleanArch.Application.Interfaces.Service;

public interface IKategoriService
{
    public List<Kategori> GetAllKategori();
    public Kategori? GetKategoriById(Guid id);
    public Kategori TambahKategori(KategoriDto kategoriParam);
    public Kategori? UpdateKategori(Guid id, KategoriDto kategoriParam);
    public void DeleteKategori(Guid id);
}