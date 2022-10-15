using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaBordaChapada
{
    IEnumerable<AreaBordaChapada> RecuperarTodos();

    IEnumerable<AreaBordaChapada> RecuperarPorTerritorioId(int territorioId);
}