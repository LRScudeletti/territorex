using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaBordaChapadaService : IAreaBordaChapada
{
    private readonly IStringLocalizer<Resource> _localizer;
    
    public AreaBordaChapadaService(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<AreaBordaChapada> RecuperarTodos()
    {
        var area = AreaBordaChapadaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }

    public IReadOnlyList<AreaBordaChapada> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaBordaChapadaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }
}