using TerritorEx.Api.Models.AreaTerritorial;

namespace TerritorEx.Api.Interfaces.AreaTerritorial;

public interface INivelTerritorio
{
    IReadOnlyList<NivelTerritorio> RecuperarTodos();

    NivelTerritorio RecuperarPorId(int territorioId);
}

