using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaDeclividadeMaior45Service : IAreaDeclividadeMaior45
{
    private readonly IStringLocalizer<Resource> _localizer;

    public AreaDeclividadeMaior45Service(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<AreaDeclividadeMaior45> RecuperarTodos()
    {
        var area = AreaDeclividadeMaior45Repository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }

    public IReadOnlyList<AreaDeclividadeMaior45> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaDeclividadeMaior45Repository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }
}