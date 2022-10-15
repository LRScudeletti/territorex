using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaConsolidada
{
    IReadOnlyList<AreaConsolidada> RecuperarTodos();

    IReadOnlyList<AreaConsolidada> RecuperarPorTerritorioId(int territorioId);
}