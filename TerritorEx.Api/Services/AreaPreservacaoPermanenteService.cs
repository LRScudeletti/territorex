using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaPreservacaoPermanenteService : IAreaPreservacaoPermanente
{
    private readonly IStringLocalizer<Resource> _localizer;

    public AreaPreservacaoPermanenteService(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<AreaPreservacaoPermanente> RecuperarTodos()
    {
        var area = AreaPreservacaoPermanenteRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }

    public IReadOnlyList<AreaPreservacaoPermanente> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaPreservacaoPermanenteRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }
}