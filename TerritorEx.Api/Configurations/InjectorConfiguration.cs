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
        services.AddScoped<IAreaConsolidadaRepository, AreaConsolidadaRepository>();
        services.AddScoped<IAreaDeclividadeMaior45Repository, AreaDeclividadeMaior45Repository>();
        services.AddScoped<IAreaHidrografiaRepository, AreaHidrografiaRepository>();
        services.AddScoped<IAreaImovelRepository, AreaImovelRepository>();
        services.AddScoped<IAreaNascenteOlhoDAguaRepository, AreaNascenteOlhoDAguaRepository>();
        services.AddScoped<IAreaManguezalRepository, AreaManguezalRepository>();
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
        #endregion
    }
}