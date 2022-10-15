using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaBanhado
{
    IReadOnlyList<AreaBanhado> RecuperarTodos();

    IReadOnlyList<AreaBanhado> RecuperarPorTerritorioId(int territorioId);
}