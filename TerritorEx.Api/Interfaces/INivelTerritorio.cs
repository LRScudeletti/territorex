using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface INivelTerritorio
{
    IReadOnlyList<NivelTerritorio> RecuperarTodos();

    NivelTerritorio RecuperarPorId(int territorioId);
}

