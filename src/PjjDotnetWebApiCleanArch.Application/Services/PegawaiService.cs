using AutoMapper;
using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Application.Interfaces;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Repository;
using PjjDotnetWebApiCleanArch.Domain.Entities;

namespace PjjDotnetWebApiCleanArch.Application.Services;

public class PegawaiService(IPegawaiRepository _repository,
    IUnitOfWorks _unitOfWorks,
    IMapper _mapper)
{
    public PaginationResponse<Pegawai> GetAllPegawai(PegawaiQueryParam pegawaiQueryParam)
    {

        List<Pegawai> data;
        int count;

        if(pegawaiQueryParam.Nama != null)
        {
            data = [.. _repository.GetAll(p => p.Nama.ToLower().Contains(pegawaiQueryParam.Nama.ToLower()),
                p => p.Nama,
                pegawaiQueryParam.Offset,
                pegawaiQueryParam.Limit)];

            count = _repository.Count(p => p.Nama.ToLower().Contains(pegawaiQueryParam.Nama.ToLower()));
        }
        else
        {
            data = [.. _repository.GetAll(p => p.Nama,
                pegawaiQueryParam.Offset,
                pegawaiQueryParam.Limit)];

            count = _repository.Count();
        }

        return new PaginationResponse<Pegawai>()
        {
            Total = count,
            Items = data
        };
    }

    public Pegawai? GetById(Guid id)
    {
        return _repository.Get(p => p.Id == id.ToString());
    }

    public Pegawai CreatePegawai(PegawaiDto pegawaiParam)
    {
        var pegawai = _mapper.Map<Pegawai>(pegawaiParam);
        _repository.Create(pegawai);
        _unitOfWorks.SaveChanges();
        return pegawai;
    }

    public Pegawai UpdatePegawai(Guid id, PegawaiDto pegawaiDto)
    {
        var pegawai = _repository.Get(p => p.Id == id.ToString());
        if (pegawai == null) throw new Exception("Pegawai tidak ditemukan");
        pegawai.Nama = pegawaiDto.Nama;
        pegawai.Jabatan = pegawaiDto.Jabatan;
        pegawai.NIP = pegawaiDto.NIP;
        pegawai.TanggalMasuk = pegawaiDto.TanggalMasuk.GetValueOrDefault();
        pegawai.Gaji = pegawaiDto.Gaji.GetValueOrDefault();
        _repository.Update(pegawai);
        _unitOfWorks.SaveChanges();
        return pegawai;
    }

    public Pegawai PartialUpdatePegawai(Guid id, PegawaiDto pegawaiParam)
    {
        var pegawai = _repository.Get(x => x.Id == id.ToString());
        if (pegawai == null) throw new Exception("Pegawai tidak ditemukan");
        _repository.Update(pegawai);
        _repository.PartialUpdatePegawai(pegawaiParam, pegawai);
        _unitOfWorks.SaveChanges();
        return pegawai;
    }

    public void DeletePegawai(Guid id)
    {
        var pegawai = _repository.Get(p => p.Id == id.ToString());
        if (pegawai == null) throw new Exception("Pegawai tidak ditemukan");
        pegawai.DeletedAt = DateTime.Now;
        _repository.Update(pegawai);
        _unitOfWorks.SaveChanges();
    }
}
