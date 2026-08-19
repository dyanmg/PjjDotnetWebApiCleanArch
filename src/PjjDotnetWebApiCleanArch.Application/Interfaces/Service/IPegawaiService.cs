using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Domain.Entities;

namespace PjjDotnetWebApiCleanArch.Application.Interfaces.Service;

public interface IPegawaiService
{
    public PaginationResponse<Pegawai> GetAllPegawai(PegawaiQueryParam pegawaiQueryParam);
    public Pegawai? GetById(Guid id);
    public Pegawai CreatePegawai(PegawaiDto pegawaiParam);
    public Pegawai UpdatePegawai(Guid id, PegawaiDto pegawaiDto);
    public Pegawai PartialUpdatePegawai(Guid id, PegawaiDto pegawaiParam);
    public void DeletePegawai(Guid id);
}