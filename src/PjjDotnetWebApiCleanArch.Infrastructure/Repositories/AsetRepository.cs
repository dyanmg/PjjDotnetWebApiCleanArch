using Microsoft.EntityFrameworkCore;
using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Repository;
using PjjDotnetWebApiCleanArch.Domain.Entities;
using PjjDotnetWebApiCleanArch.Infrastructure.Persistence;

namespace PjjDotnetWebApiCleanArch.Infrastructure.Repositories;

internal class AsetRepository(AppDbContext _context)
    : Repository<Aset>(_context), IAsetRepository
{
    public Tuple<List<Aset>, int> GetAllAset(AsetQueryParam queryParam)
    {
        var asetQuery = _context.Aset
            .Include(x => x.Kategori).AsQueryable();              ;
        if(queryParam.Kategori != null)
        {
            asetQuery = asetQuery.Where(x => x.Kategori.Nama.Contains(queryParam.Kategori));
        }
        if(queryParam.IncludeDeleted == true)
        {
            asetQuery = asetQuery.IgnoreQueryFilters();
        }
        asetQuery= asetQuery.Where(x => x.Nilai > 100000);
        int count = asetQuery.Count();
        var result = asetQuery.OrderBy(x => x.Nama).Skip(queryParam.Offset).Take(queryParam.Limit).ToList();
        return Tuple.Create(result, count);
    }

    public List<AsetGroupByKategori> GetAsetGroupingByKategori()
    {
        var aset = _context.Aset.Include(x => x.Kategori).GroupBy(x => x.Kategori.Nama).Select(x => new AsetGroupByKategori()
        {
            KategoriName = x.Key,
            Assets = x.ToList(),
            TotalNilaiAset = x.Sum(y => y.Nilai)
        }).ToList();

        return aset;
    }

    public async Task<Aset?> GetByIdIncludeKategory(Guid id)
    {
        return await _context.Aset
            .Include(x => x.Kategori)                
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public void UpdatePartialAset<TParamEntity>(TParamEntity asetParam, Aset asetTarget)
    {
        _context.PartialUpdate(asetParam, asetTarget);
    }
}