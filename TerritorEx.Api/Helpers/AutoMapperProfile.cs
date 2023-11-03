using AutoMapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Models;

namespace TerritorEx.Api.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<AreaAltitudeSuperior1800, AreaAltitudeSuperior1800Model>();
    }
}