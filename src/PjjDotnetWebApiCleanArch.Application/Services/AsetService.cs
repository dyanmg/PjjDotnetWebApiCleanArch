using AutoMapper;
using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Application.Interfaces;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Repository;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Service;
using PjjDotnetWebApiCleanArch.Domain.Entities;

namespace PjjDotnetWebApiCleanArch.Application.Services;

public class AsetService(IRepository<Aset> _repository, IUnitOfWorks _unitOfWorks, IMapper _mapper) : IAsetService
{
    public AsetDto CreateAset(AsetParamDto asetParam)
    {
        var aset = _mapper.Map<Aset>(asetParam);
        var kategori = _repository.Get(x => x.Id == aset.KategoriId);
        if(kategori == null)
        {
            throw new Exception("Kategori tidak ditemukan");
        }
        _repository.Create(aset);
        _unitOfWorks.SaveChanges();
        return _mapper.Map<AsetDto>(aset);
    }

    public void DeleteAset(Guid id)
    {
        var aset = _repository.Get(x => x.Id == id);
        if(aset == null)
        {
            throw new Exception("Aset tidak ditemukan");
        }
        _repository.Delete(aset);
        _unitOfWorks.SaveChanges();
    }

    public Tuple<List<AsetDto>, int> GetAllAset(AsetQueryParam queryParam)
    {
        var asetQuery = _dbContext.Aset
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
        return Tuple.Create(_mapper.Map<List<AsetDto>>(result), count);
    }

    public List<AsetGroupByKategori> GetAsetGroupingByKategori()
    {
        var aset = _dbContext.Aset.Include(x => x.Kategori).GroupBy(x => x.Kategori.Nama).Select(x => new AsetGroupByKategori()
        {
            KategoriName = x.Key,
            Assets = _mapper.Map<List<AsetDto>>(x.ToList()),
            TotalNilaiAset = x.Sum(y => y.Nilai)
        }).ToList();

        return aset;
    }

    public async Task<AsetDto?> GetById(Guid id)
    {
        var aset =  await _dbContext.Aset
            .Include(x => x.Kategori)                
            .FirstOrDefaultAsync(x => x.Id == id);
        if (aset == null) return null;
        return _mapper.Map<AsetDto>(aset);
    }

    public Aset UbahPartial(Guid id, AsetParamDto asetParamDto)
    {
        var aset = _dbContext.Aset.Find(id);
        if (aset == null)
        {
            throw new Exception("Aset tidak ditemukan");
        }
        //var reflection = typeof(AsetParamDto);

        //foreach (var property in _dbContext.Entry(aset).Properties)
        //{
        //    var asetParamValue = reflection.GetProperty(property.Metadata.Name)?.GetValue(asetParamDto);
        //    if (asetParamValue == null)
        //    {
        //        property.IsModified = false;
        //    }
        //    else
        //    {
        //        // Set nilai dari asetParam ke aset jika tidak null
        //        property.CurrentValue = asetParamValue;
        //    }
        //}           
        _dbContext.PartialUpdate(asetParamDto, aset);
        _dbContext.SaveChanges();
        return aset;
    }

    public AsetDto UpdateAset(Guid id, AsetParamDto asetDtoParam)
    {
        var aset = _repository.Get(x => x.Id == id);
        if(aset == null)
        {
            throw new Exception("Aset tidak ditemukan");
        }
        var kategori = _repository.Get(x => x.Id == asetDtoParam.KategoriId);

        if (kategori == null)
        {
            throw new Exception("Kategori tidak ditemukan");
        }
        aset.Nama = asetDtoParam.Nama;
        aset.KategoriId = asetDtoParam.KategoriId.Value;
        aset.TanggalPerolehan = asetDtoParam.TanggalPerolehan.Value;
        aset.Nilai = asetDtoParam.Nilai.Value;

        var kategoriData = _repository.Get(x => x.Id == asetDtoParam.KategoriId);


        _repository.Update(aset);
        _unitOfWorks.SaveChanges();
        return _mapper.Map<AsetDto>(aset);
    }
    //1. Get All Aset
    //2. Get Aset By Id
    //3. Create Aset
    //4. Update Aset
    //5. Delete Aset

}
