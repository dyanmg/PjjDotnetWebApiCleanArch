using AutoMapper;
using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Application.Interfaces;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Repository;
using PjjDotnetWebApiCleanArch.Domain.Entities;

namespace PjjDotnetWebApiCleanArch.Application.Services;

public class KategoriService(IRepository<Kategori> _repository,
    IMapper _mapper,
    IUnitOfWorks _unitOfWorks)
{
    public List<Kategori> GetAllKategori()
    {
        return _repository.GetAll(k => k.DeletedAt == null);
    }

    public Kategori? GetKategoriById(Guid id)
    {
        return _repository.Get(x => x.Id == id);
    }

    public Kategori TambahKategori(KategoriDto kategoriParam)
    {
        var kategori = _mapper.Map<Kategori>(kategoriParam);
        _repository.Create(kategori);
        _unitOfWorks.SaveChanges();
        return kategori;
    }


    public Kategori? UpdateKategori(Guid id, KategoriDto kategoriParam)
    {
        var kategori = _repository.Get(x => x.Id == id);
        if (kategori == null) return null;
        kategori.Nama = kategoriParam.Nama;
        _repository.Update(kategori);
        _unitOfWorks.SaveChanges();
        return kategori;
    }

    public void DeleteKategori(Guid id)
    {
        var kategori = _repository.Get(x => x.Id == id);
        if (kategori == null) throw new Exception("Kategori tidak ditemukan");
        _repository.Delete(kategori);
        _unitOfWorks.SaveChanges();
    }
}
