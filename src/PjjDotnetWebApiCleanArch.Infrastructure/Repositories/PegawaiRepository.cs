using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Repository;
using PjjDotnetWebApiCleanArch.Domain.Entities;
using PjjDotnetWebApiCleanArch.Infrastructure.Persistence;

namespace PjjDotnetWebApiCleanArch.Infrastructure.Repositories;

internal class PegawaiRepository(AppDbContext _context) :
    Repository<Pegawai>(_context), IPegawaiRepository
{
    public void PartialUpdatePegawai<TParamEntity>(TParamEntity pegawaiParam, Pegawai pegawaiTarget)
    {
        _context.PartialUpdate(pegawaiParam, pegawaiTarget);
    }
}