using TerritorEx.Api.Interfaces.AreaTerritorial;
using TerritorEx.Api.Models.AreaTerritorial;
using TerritorEx.Api.Repositories.AreaTerritorial;

namespace TerritorEx.Api.Services.AreaTerritorial;

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