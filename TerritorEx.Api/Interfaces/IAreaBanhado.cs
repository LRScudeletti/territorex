using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaBanhado
{
    IReadOnlyList<Area> RecuperarTodos();

    IReadOnlyList<Area> RecuperarPorTerritorioId(int territorioId);
}