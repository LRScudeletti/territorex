using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaServidaoAdministrativaService : IAreaServidaoAdministrativa
{
    private readonly IStringLocalizer<Resource> _localizer;

    public AreaServidaoAdministrativaService(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<AreaServidaoAdministrativa> RecuperarTodos()
    {
        var area = AreaServidaoAdministrativaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }

    public IReadOnlyList<AreaServidaoAdministrativa> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaServidaoAdministrativaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }
}