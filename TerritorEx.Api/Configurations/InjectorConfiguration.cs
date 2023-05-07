using TerritorEx.Api.Authorization;
using TerritorEx.Api.Repositories;
using TerritorEx.Api.Services;

namespace TerritorEx.Api.Configurations;

public static class InjectorConfiguration
{
    public static void Register(this IServiceCollection services)
    {
        services.AddScoped<IJwtUtils, JwtUtils>();

        #region [ Repository ]
        services.AddScoped<IAreaAltitudeSuperior1800Repository, AreaAltitudeSuperior1800Repository>();
        services.AddScoped<IAreaBanhadoRepository, AreaBanhadoRepository>();
        services.AddScoped<IAreaBordaChapadaRepository, AreaBordaChapadaRepository>();
        services.AddScoped<IAreaConsolidadaRepository, AreaConsolidadaRepository>();
        services.AddScoped<IAreaDeclividadeMaior45Repository, AreaDeclividadeMaior45Repository>();
        services.AddScoped<IAreaHidrografiaRepository, AreaHidrografiaRepository>();
        services.AddScoped<IAreaImovelRepository, AreaImovelRepository>();
        services.AddScoped<IAreaManguezalRepository, AreaManguezalRepository>();
        services.AddScoped<IAreaNascenteOlhoDAguaRepository, AreaNascenteOlhoDAguaRepository>();
        services.AddScoped<IAreaPousioRepository, AreaPousioRepository>();
        services.AddScoped<IAreaPreservacaoPermanenteRepository, AreaPreservacaoPermanenteRepository>();
        services.AddScoped<IAreaReservaLegalRepository, AreaReservaLegalRepository>();
        services.AddScoped<IAreaRestingaRepository, AreaRestingaRepository>();
        services.AddScoped<IAreaServidaoAdministrativaRepository, AreaServidaoAdministrativaRepository>();
        services.AddScoped<IAreaTopoMorroRepository, AreaTopoMorroRepository>();
        services.AddScoped<IAreaVegetacaoNativaRepository, AreaVegetacaoNativaRepository>();
        services.AddScoped<IAreaVeredaRepository, AreaVeredaRepository>();
        services.AddScoped<INivelTerritorioRepository, NivelTerritorioRepository>();
        services.AddScoped<ISituacaoImovelRepository, SituacaoImovelRepository>();
        services.AddScoped<ITipoImovelRepository, TipoImovelRepository>();
        services.AddScoped<ITerritorioRepository, TerritorioRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        #endregion

        #region [ Services ]
        services.AddScoped<IAreaAltitudeSuperior1800Service, AreaAltitudeSuperior1800Service>();
        services.AddScoped<IAreaBanhadoService, AreaBanhadoService>();
        services.AddScoped<IAreaBordaChapadaService, AreaBordaChapadaService>();
        services.AddScoped<IAreaConsolidadaService, AreaConsolidadaService>();
        services.AddScoped<IAreaDeclividadeMaior45Service, AreaDeclividadeMaior45Service>();
        services.AddScoped<IAreaHidrografiaService, AreaHidrografiaService>();
        services.AddScoped<IAreaImovelService, AreaImovelService>();
        services.AddScoped<IAreaManguezalService, AreaManguezalService>();
        services.AddScoped<IAreaNascenteOlhoDAguaService, AreaNascenteOlhoDAguaService>();
        services.AddScoped<IAreaPousioService, AreaPousioService>();
        services.AddScoped<IAreaPreservacaoPermanenteService, AreaPreservacaoPermanenteService>();
        services.AddScoped<IAreaReservaLegalService, AreaReservaLegalService>();
        services.AddScoped<IAreaRestingaService, AreaRestingaService>();
        services.AddScoped<IAreaServidaoAdministrativaService, AreaServidaoAdministrativaService>();
        services.AddScoped<IAreaTopoMorroService, AreaTopoMorroService>();
        services.AddScoped<IAreaVegetacaoNativaService, AreaVegetacaoNativaService>();
        services.AddScoped<IAreaVeredaService, AreaVeredaService>();
        services.AddScoped<INivelTerritorioService, NivelTerritorioService>();
        services.AddScoped<ISituacaoImovelService, SituacaoImovelService>();
        services.AddScoped<ITipoImovelService, TipoImovelService>();
        services.AddScoped<ITerritorioService, TerritorioService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        #endregion
    }
}