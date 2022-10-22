using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaManguezal
{
    IReadOnlyList<AreaManguezal> RecuperarTodos();

    IReadOnlyList<AreaManguezal> RecuperarPorTerritorioId(int territorioId);
}