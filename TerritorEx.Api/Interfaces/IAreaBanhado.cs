using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaBanhado
{
    IEnumerable<AreaBanhado> RecuperarTodos();

    IEnumerable<AreaBanhado> RecuperarPorTerritorioId(int territorioId);
}