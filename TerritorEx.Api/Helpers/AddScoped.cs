using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Helpers;

public static class AddScoped
{
    public static void AdicionarInterface(IServiceCollection services)
    {
        services.AddScoped<IAreaAltitudeSuperior1800, AreaAltitudeSuperior1800Service>();
        services.AddScoped<IAreaBanhado, AreaBanhadoService>();
        services.AddScoped<IAreaBordaChapada, AreaBordaChapadaService>();
        services.AddScoped<IAreaConsolidada, AreaConsolidadaService>();

        services.AddScoped<INivelTerritorio, NivelTerritorioService>();

        services.AddScoped<ITerritorio, TerritorioService>();
    }
}