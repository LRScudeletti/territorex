using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces.Area;

public interface IAreaManguezal
{
    IReadOnlyList<AreaManguezal> RecuperarTodos();

    IReadOnlyList<AreaManguezal> RecuperarPorTerritorioId(int territorioId);
}