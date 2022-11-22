using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaUsoRestritoService : IAreaUsoRestrito
{
    private readonly IStringLocalizer<Resource> _localizer;

    public AreaUsoRestritoService(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<AreaUsoRestrito> RecuperarTodos()
    {
        var area = AreaUsoRestritoRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }

    public IReadOnlyList<AreaUsoRestrito> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaUsoRestritoRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }
}