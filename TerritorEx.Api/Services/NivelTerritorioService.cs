using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class NivelTerritorioService : INivelTerritorio
{
    private readonly IStringLocalizer<Resource> _localizer;

    public NivelTerritorioService(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<NivelTerritorio> RecuperarTodos()
    {
        var nivelTerritorio = NivelTerritorioRepository.RecuperarTodos();

        if (!nivelTerritorio.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return nivelTerritorio;
    }

    public NivelTerritorio RecuperarPorId(int nivelId)
    {
        var nivelTerritorio = NivelTerritorioRepository.RecuperarPorId(nivelId);

        if (nivelTerritorio == null)
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return nivelTerritorio;
    }
}