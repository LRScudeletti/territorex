using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaPousio
{
    IReadOnlyList<AreaPousio> RecuperarTodos();

    IReadOnlyList<AreaPousio> RecuperarPorTerritorioId(int territorioId);
}