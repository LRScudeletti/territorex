using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaBordaChapada
{
    IReadOnlyList<AreaBordaChapada> RecuperarTodos();

    IReadOnlyList<AreaBordaChapada> RecuperarPorTerritorioId(int territorioId);
}