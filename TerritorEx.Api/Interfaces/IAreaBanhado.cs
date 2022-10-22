using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaBanhado
{
    IReadOnlyList<AreaBanhado> RecuperarTodos();

    IReadOnlyList<AreaBanhado> RecuperarPorTerritorioId(int territorioId);
}