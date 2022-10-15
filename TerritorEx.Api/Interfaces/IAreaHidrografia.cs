using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaHidrografia
{
    IReadOnlyList<AreaHidrografia> RecuperarTodos();

    IReadOnlyList<AreaHidrografia> RecuperarPorTerritorioId(int territorioId);
}