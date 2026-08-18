using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Domain.Entities;

namespace PjjDotnetWebApiCleanArch.Application.Interfaces.Service;

public interface IAsetService
{
    Tuple<List<AsetDto>, int> GetAllAset(AsetQueryParam queryParam);
    Task<AsetDto?> GetById(Guid id);
    AsetDto CreateAset(AsetParamDto asetParam);
    AsetDto UpdateAset(Guid id, AsetParamDto asetDtoParam);
    void DeleteAset(Guid id);
    List<AsetGroupByKategori> GetAsetGroupingByKategori();
    Aset UbahPartial(Guid id, AsetParamDto asetParamDto);
}
