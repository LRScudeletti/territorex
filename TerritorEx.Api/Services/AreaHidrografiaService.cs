using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaHidrografiaService : IAreaHidrografia
{
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaHidrografiaService(IStringLocalizer<Resources> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<Area> RecuperarTodos()
    {
        var area = AreaHidrografiaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }

    public IReadOnlyList<Area> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaHidrografiaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }
}