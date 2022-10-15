using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.Territorio;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class TerritorioService : ITerritorio
{
    public IReadOnlyList<Territorio> RecuperarTodos()
    {
        var territorio = TerritorioRepository.RecuperarTodos();

        if (!territorio.Any())
            throw new KeyNotFoundException(Properties.Resources.TerritorioNaoEncontrado);

        return territorio;
    }

    public Territorio RecuperarPorId(int territorioId)
    {
        var territorio = TerritorioRepository.RecuperarPorId(territorioId);

        if (territorio == null)
            throw new KeyNotFoundException(Properties.Resources.TerritorioNaoEncontrado);

        return territorio;
    }

    public IReadOnlyList<Territorio> RecuperarPorNome(string territorioNome)
    {
        var territorio = TerritorioRepository.RecuperarPorNome(territorioNome);

        if (!territorio.Any())
            throw new KeyNotFoundException(Properties.Resources.TerritorioNaoEncontrado);

        return territorio;
    }

    public IReadOnlyList<Territorio> RecuperarPorPaiId(int territorioPaiId)
    {
        var territorio = TerritorioRepository.RecuperarPorPaiId(territorioPaiId);

        if (!territorio.Any())
            throw new KeyNotFoundException(Properties.Resources.TerritorioNaoEncontrado);

        return territorio;
    }

    public IReadOnlyList<Territorio> RecuperarPorNivelTerritorioId(int nivelTerritorioId)
    {
        var territorio = TerritorioRepository.RecuperarPorNivelTerritorioId(nivelTerritorioId);

        if (!territorio.Any())
            throw new KeyNotFoundException(Properties.Resources.TerritorioNaoEncontrado);

        return territorio;
    }

    public TerritorioHierarquia RecuperarHierarquia(int territoryId)
    {
        var territorio = TerritorioRepository.RecuperarHierarquia(territoryId);

        if (territorio == null)
            throw new KeyNotFoundException(Properties.Resources.TerritorioNaoEncontrado);

        return territorio;
    }
}