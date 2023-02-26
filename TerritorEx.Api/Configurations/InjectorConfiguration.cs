using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Configurations;

public static class InjectorConfiguration
{
    public static void Register(this IServiceCollection services)
    {
        services.AddScoped<IAreaAltitudeSuperior1800, AreaAltitudeSuperior1800Service>();
        services.AddScoped<IAreaBanhado, AreaBanhadoService>();
        // services.AddScoped<IAreaBordaChapada, AreaBordaChapadaService>();
        // services.AddScoped<IAreaConsolidada, AreaConsolidadaService>();
        // services.AddScoped<IAreaDeclividadeMaior45, AreaDeclividadeMaior45Service>();
        // services.AddScoped<IAreaHidrografia, AreaHidrografiaService>();
        // services.AddScoped<IAreaImovel, AreaImovelService>();
        // services.AddScoped<IAreaManguezal, AreaManguezalService>();
        // services.AddScoped<IAreaNascenteOlhoDAgua, AreaNascenteOlhoDAguaService>();
        // services.AddScoped<IAreaPousio, AreaPousioService>();
        // services.AddScoped<IAreaPreservacaoPermanente, AreaPreservacaoPermanenteService>();
        // services.AddScoped<IAreaReservaLegal, AreaReservaLegalService>();
        // services.AddScoped<IAreaRestinga, AreaRestingaService>();
        // services.AddScoped<IAreaServidaoAdministrativa, AreaServidaoAdministrativaService>();
        // services.AddScoped<IAreaTopoMorro, AreaTopoMorroService>();
        // services.AddScoped<IAreaUsoRestrito, AreaUsoRestritoService>();
        // services.AddScoped<IAreaVegetacaoNativa, AreaVegetacaoNativaService>();
        // services.AddScoped<IAreaVereda, AreaVeredaService>();
        // services.AddScoped<INivelTerritorio, NivelTerritorioService>();
        // services.AddScoped<ISituacaoImovel, SituacaoImovelService>();
        // services.AddScoped<ITerritorio, TerritorioService>();
        // services.AddScoped<ITipoImovel, TipoImovelService>();
    }
}