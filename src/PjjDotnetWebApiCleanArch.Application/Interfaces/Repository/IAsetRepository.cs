using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Domain.Entities;

namespace PjjDotnetWebApiCleanArch.Application.Interfaces.Repository;

public interface IAsetRepository : IRepository<Aset>
{
    public Tuple<List<Aset>, int> GetAllAset(AsetQueryParam queryParam);
    public List<AsetGroupByKategori> GetAsetGroupingByKategori();
    public Task<Aset?> GetByIdIncludeKategory(Guid id);
    public void UpdatePartialAset<TParamEntity>(TParamEntity aasetParamDto, Aset asetTarget);
}