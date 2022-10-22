using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces.Area;

public interface IAreaTopoMorro
{
    IReadOnlyList<AreaTopoMorro> RecuperarTodos();

    IReadOnlyList<AreaTopoMorro> RecuperarPorTerritorioId(int territorioId);
}