using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaTopoMorro
{
    IReadOnlyList<AreaTopoMorro> RecuperarTodos();

    IReadOnlyList<AreaTopoMorro> RecuperarPorTerritorioId(int territorioId);
}