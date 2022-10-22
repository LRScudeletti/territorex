using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces.Area;

public interface IAreaConsolidada
{
    IReadOnlyList<AreaConsolidada> RecuperarTodos();

    IReadOnlyList<AreaConsolidada> RecuperarPorTerritorioId(int territorioId);
}