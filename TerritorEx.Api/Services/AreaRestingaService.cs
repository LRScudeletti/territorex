using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaRestingaService : IAreaRestinga
{
    private readonly IStringLocalizer<Resource> _localizer;

    public AreaRestingaService(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<AreaRestinga> RecuperarTodos()
    {
        var area = AreaRestingaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }

    public IReadOnlyList<AreaRestinga> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaRestingaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }
}