using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces.Area;

public interface IAreaPousio
{
    IReadOnlyList<AreaPousio> RecuperarTodos();

    IReadOnlyList<AreaPousio> RecuperarPorTerritorioId(int territorioId);
}