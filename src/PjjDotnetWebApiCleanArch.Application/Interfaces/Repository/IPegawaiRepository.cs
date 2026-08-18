using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Domain.Entities;

namespace PjjDotnetWebApiCleanArch.Application.Interfaces.Repository;

public interface IPegawaiRepository : IRepository<Pegawai>
{
    void PartialUpdatePegawai<TParamEntity>(TParamEntity pegawaiParam, Pegawai pegawaiTarget);
}