using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaDeclividadeMaior45Service : IAreaDeclividadeMaior45
{
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaDeclividadeMaior45Service(IStringLocalizer<Resources> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<Area> RecuperarTodos()
    {
        var area = AreaDeclividadeMaior45Repository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }

    public IReadOnlyList<Area> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaDeclividadeMaior45Repository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }
}