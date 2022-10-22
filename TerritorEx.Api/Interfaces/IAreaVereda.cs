using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaVereda
{
    IReadOnlyList<AreaVereda> RecuperarTodos();

    IReadOnlyList<AreaVereda> RecuperarPorTerritorioId(int territorioId);
}