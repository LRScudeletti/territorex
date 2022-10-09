using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Helpers;

public static class AddScoped
{
    public static void AdicionarInterface(IServiceCollection services)
    {
        services.AddScoped<ITerritorio, TerritorioService>();
        services.AddScoped<INivelTerritorio, NivelTerritorioService>();
        services.AddScoped<IAreaAltitudeSuperior1800, AreaAltitudeSuperior1800Service>();
    }
}