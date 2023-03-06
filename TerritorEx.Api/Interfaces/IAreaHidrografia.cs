using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaHidrografia
{
    IReadOnlyList<Area> RecuperarTodos();

    IReadOnlyList<Area> RecuperarPorTerritorioId(int territorioId);
}