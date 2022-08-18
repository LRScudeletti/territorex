namespace TerritorEx.Api.Helpers;

using AutoMapper;
using Entities;
using Models.Territory;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TerritoryCreateModel, TerritoryEntity>();

        CreateMap<TerritoryUpdateModel, TerritoryEntity>()
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