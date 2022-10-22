using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Interfaces.Area;
using TerritorEx.Api.Services;
using TerritorEx.Api.Services.Area;

namespace TerritorEx.Api.Helpers;

public static class AddScoped
{
    public static void AdicionarInterface(IServiceCollection services)
    {
        services.AddScoped<IAreaAltitudeSuperior1800, AreaAltitudeSuperior1800Service>();
        services.AddScoped<IAreaBanhado, AreaBanhadoService>();
        services.AddScoped<IAreaBordaChapada, AreaBordaChapadaService>();
        services.AddScoped<IAreaConsolidada, AreaConsolidadaService>();
        services.AddScoped<IAreaDeclividadeMaior45, AreaDeclividadeMaior45Service>();
        services.AddScoped<IAreaHidrografia, AreaHidrografiaService>();
        services.AddScoped<IAreaImovel, AreaImovelService>();
        services.AddScoped<IAreaManguezal, AreaManguezalService>();
        services.AddScoped<IAreaNascenteOlhoDAgua, AreaNascenteOlhoDAguaService>();
        services.AddScoped<IAreaPousio, AreaPousioService>();
        services.AddScoped<IAreaPreservacaoPermanente, AreaPreservacaoPermanenteService>();
        services.AddScoped<IAreaReservaLegal, AreaReservaLegalService>();
        services.AddScoped<IAreaRestinga, AreaRestingaService>();
        services.AddScoped<IAreaServidaoAdministrativa, AreaServidaoAdministrativaService>();
        services.AddScoped<IAreaTopoMorro, AreaTopoMorroService>();
        services.AddScoped<IAreaUsoRestrito, AreaUsoRestritoService>();
        services.AddScoped<IAreaVegetacaoNativa, AreaVegetacaoNativaService>();
        services.AddScoped<IAreaVereda, AreaVeredaService>();

        services.AddScoped<INivelTerritorio, NivelTerritorioService>();

        services.AddScoped<ITerritorio, TerritorioService>();
    }
}