using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Repositories;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Configurations;

public static class InjectorConfiguration
{
    public static void Register(this IServiceCollection services)
    {
        #region [ Repository ]
        services.AddScoped<IAreaAltitudeSuperior1800Repository, AreaAltitudeSuperior1800Repository>();
        services.AddScoped<IAreaBanhadoRepository, AreaBanhadoRepository>();
        services.AddScoped<IAreaBordaChapadaRepository, AreaBordaChapadaRepository>();
        services.AddScoped<IAreaImovelRepository, AreaImovelRepository>();
        #endregion

        #region [ Services ]
        services.AddScoped<IAreaAltitudeSuperior1800Service, AreaAltitudeSuperior1800Service>();
        services.AddScoped<IAreaBanhadoService, AreaBanhadoService>();
        services.AddScoped<IAreaBordaChapadaService, AreaBordaChapadaService>();
        services.AddScoped<IAreaImovelService, AreaImovelService>();
        #endregion

        services.AddScoped<IAreaConsolidada, AreaConsolidadaService>();
        services.AddScoped<IAreaDeclividadeMaior45, AreaDeclividadeMaior45Service>();
        services.AddScoped<IAreaHidrografia, AreaHidrografiaService>();

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