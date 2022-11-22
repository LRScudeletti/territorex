using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaNascenteOlhoDAguaService : IAreaNascenteOlhoDAgua
{
    private readonly IStringLocalizer<Resource> _localizer;

    public AreaNascenteOlhoDAguaService(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<AreaNascenteOlhoDAgua> RecuperarTodos()
    {
        var area = AreaNascenteOlhoDAguaRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }

    public IReadOnlyList<AreaNascenteOlhoDAgua> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaNascenteOlhoDAguaRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return area;
    }
}