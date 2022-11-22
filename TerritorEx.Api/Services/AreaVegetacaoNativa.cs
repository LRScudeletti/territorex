using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaVegetacaoNativaService : IAreaVegetacaoNativa
{
    private readonly IStringLocalizer<Resource> _localizer;

    public AreaVegetacaoNativaService(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<AreaVegetacaoNativa> RecuperarTodos()
    {
        var area = AreaVegetacaoNativaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }

    public IReadOnlyList<AreaVegetacaoNativa> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaVegetacaoNativaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }
}