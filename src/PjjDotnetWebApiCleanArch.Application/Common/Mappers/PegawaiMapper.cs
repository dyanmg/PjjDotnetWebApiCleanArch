using AutoMapper;
using PjjDotnetWebApiCleanArch.Application.DTOs;
using PjjDotnetWebApiCleanArch.Domain.Entities;

namespace PjjDotnetWebApiCleanArch.Application.Common.Mappers;

public class PegawaiMapper : Profile
{
    public PegawaiMapper()
    {
        CreateMap<Pegawai, PegawaiDto>();
        CreateMap<PegawaiDto, Pegawai>();

        CreateMap<AsetDto, Aset>();
        CreateMap<Aset, AsetDto>();

        CreateMap<AsetParamDto, Aset>();

        CreateMap<RegisterPegawaiDto, Pegawai>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id ?? Guid.NewGuid()))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.NIP));
    }
}
