using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaBordaChapada
{
    IReadOnlyList<AreaBordaChapada> RecuperarTodos();

    IReadOnlyList<AreaBordaChapada> RecuperarPorTerritorioId(int territorioId);
}