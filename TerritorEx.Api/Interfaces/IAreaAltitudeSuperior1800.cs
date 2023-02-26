using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaAltitudeSuperior1800
{
    IReadOnlyList<Area> RecuperarTodos();

    IReadOnlyList<Area> RecuperarPorTerritorioId(int territorioId);
}