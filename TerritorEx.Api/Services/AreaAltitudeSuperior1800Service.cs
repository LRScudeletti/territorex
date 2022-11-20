using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaAltitudeSuperior1800Service : IAreaAltitudeSuperior1800
{
    private readonly IStringLocalizer<Resource> _localizer;

    public AreaAltitudeSuperior1800Service(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<AreaAltitudeSuperior1800> RecuperarTodos()
    {
        var area = AreaAltitudeSuperior1800Repository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }

    public IReadOnlyList<AreaAltitudeSuperior1800> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaAltitudeSuperior1800Repository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }
}