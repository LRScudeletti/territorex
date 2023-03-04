using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaConsolidada
{
    IReadOnlyList<Area> RecuperarTodos();

    IReadOnlyList<Area> RecuperarPorTerritorioId(int territorioId);
}