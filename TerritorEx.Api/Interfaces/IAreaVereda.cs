using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaVereda
{
    IReadOnlyList<AreaVereda> RecuperarTodos();

    IReadOnlyList<AreaVereda> RecuperarPorTerritorioId(int territorioId);
}