using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models.NivelTerritorio;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class NivelTerritorioService : INivelTerritorio
{
    public IReadOnlyList<NivelTerritorio> RecuperarTodos()
    {
        var nivelTerritorio = NivelTerritorioRepository.RecuperarTodos();

        if (!nivelTerritorio.Any())
            throw new KeyNotFoundException(Properties.Resources.NivelTerritorioNaoEncontrado);

        return nivelTerritorio;
    }

    public NivelTerritorio RecuperarPorId(int nivelId)
    {
        var nivelTerritorio = NivelTerritorioRepository.RecuperarPorId(nivelId);

        if (nivelTerritorio == null)
            throw new KeyNotFoundException(Properties.Resources.NivelTerritorioNaoEncontrado);

        return nivelTerritorio;
    }
}