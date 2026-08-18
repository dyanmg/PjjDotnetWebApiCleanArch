using AutoMapper;
using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Domain.Entities;

namespace PjjDotnetWebApiCleanArch.Application.Common.Mappers;

public class KategoriMapper : Profile
{
    public KategoriMapper()
    {
        CreateMap<KategoriDto, Kategori>();
        CreateMap<Kategori, KategoriDto>();
    }
}
