using TerritorEx.Api.Models.NivelTerritorio;

namespace TerritorEx.Api.Interfaces;

public interface INivelTerritorio
{
    IReadOnlyList<NivelTerritorio> RecuperarTodos();

    NivelTerritorio RecuperarPorId(int territorioId);
}

