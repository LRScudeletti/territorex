using AutoMapper;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Models.Usuario;

namespace TerritorEx.Api.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Usuario, AutenticarResponse>();
        CreateMap<CriarUsuario, Usuario>();
        CreateMap<AtualizarUsuario, Usuario>()
            .ForAllMembers(x => x.Condition(
                (_, _, prop) =>
                {
                    if (prop == null) return false;
                    return prop.GetType() != typeof(string) || !string.IsNullOrEmpty((string)prop);
                }
            ));
    }
}