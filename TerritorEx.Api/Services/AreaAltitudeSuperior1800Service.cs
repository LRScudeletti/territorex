using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaAltitudeSuperior1800Service : IAreaAltitudeSuperior1800
{
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaAltitudeSuperior1800Service(IStringLocalizer<Resources> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<Area> RecuperarTodos()
    {
        var area = AreaAltitudeSuperior1800Repository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }

    public IReadOnlyList<Area> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaAltitudeSuperior1800Repository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }
}