using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaPousio
{
    IReadOnlyList<AreaPousio> RecuperarTodos();

    IReadOnlyList<AreaPousio> RecuperarPorTerritorioId(int territorioId);
}