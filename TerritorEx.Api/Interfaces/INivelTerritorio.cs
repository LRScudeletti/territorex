using TerritorEx.Api.Models.NivelTerritorio;

namespace TerritorEx.Api.Interfaces;

public interface INivelTerritorio
{
    IEnumerable<NivelTerritorio> RecuperarTodos();

    NivelTerritorio RecuperarPorId(int territorioId);
}

