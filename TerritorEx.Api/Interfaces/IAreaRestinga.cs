using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaRestinga
{
    IReadOnlyList<AreaRestinga> RecuperarTodos();

    IReadOnlyList<AreaRestinga> RecuperarPorTerritorioId(int territorioId);
}