using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaUsoRestrito
{
    IReadOnlyList<AreaUsoRestrito> RecuperarTodos();

    IReadOnlyList<AreaUsoRestrito> RecuperarPorTerritorioId(int territorioId);
}