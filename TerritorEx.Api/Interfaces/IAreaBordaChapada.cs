using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaBordaChapada
{
    IReadOnlyList<Area> RecuperarTodos();

    IReadOnlyList<Area> RecuperarPorTerritorioId(int territorioId);
}