using AutoMapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Models.Territory;

namespace TerritorEx.Api.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TerritoryCreate, Territories>();

        CreateMap<TerritoryUpdate, Territories>()
            .ForAllMembers(x => x.Condition(
                (_, _, prop) =>
                {
                    // Ignore both null & empty string properties
                    if (prop == null) return false;
                    return prop.GetType() != typeof(string) || !string.IsNullOrEmpty((string)prop);
                }
            ));
    }
}