using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaTopoMorroService : IAreaTopoMorro
{
    private readonly IStringLocalizer<Resource> _localizer;

    public AreaTopoMorroService(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<AreaTopoMorro> RecuperarTodos()
    {
        var area = AreaTopoMorroRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }

    public IReadOnlyList<AreaTopoMorro> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaTopoMorroRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }
}