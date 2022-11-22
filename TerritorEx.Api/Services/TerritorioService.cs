using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class TerritorioService : ITerritorio
{
    private readonly IStringLocalizer<Resource> _localizer;

    public TerritorioService(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<Territorio> RecuperarTodos()
    {
        var territorio = TerritorioRepository.RecuperarTodos();

        if (!territorio.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return territorio;
    }

    public Territorio RecuperarPorId(int territorioId)
    {
        var territorio = TerritorioRepository.RecuperarPorId(territorioId);

        if (territorio == null)
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return territorio;
    }

    public IReadOnlyList<Territorio> RecuperarPorNome(string territorioNome)
    {
        var territorio = TerritorioRepository.RecuperarPorNome(territorioNome);

        if (!territorio.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return territorio;
    }

    public IReadOnlyList<Territorio> RecuperarPorTerritorioSuperiorId(int territorioSuperiorId)
    {
        var territorio = TerritorioRepository.RecuperarPorTerritorioSuperiorId(territorioSuperiorId);

        if (!territorio.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return territorio;
    }

    public IReadOnlyList<Territorio> RecuperarPorNivelTerritorioId(int nivelTerritorioId)
    {
        var territorio = TerritorioRepository.RecuperarPorNivelTerritorioId(nivelTerritorioId);

        if (!territorio.Any())
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return territorio;
    }

    public TerritorioHierarquia RecuperarHierarquia(int territoryId)
    {
        var territorio = TerritorioRepository.RecuperarHierarquia(territoryId);

        if (territorio == null)
            throw new KeyNotFoundException(_localizer["AreaNaoEncontrada"]);

        return territorio;
    }
}