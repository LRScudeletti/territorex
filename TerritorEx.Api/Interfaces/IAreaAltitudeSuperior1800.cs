using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaAltitudeSuperior1800
{
    IReadOnlyList<AreaAltitudeSuperior1800> RecuperarTodos();

    IReadOnlyList<AreaAltitudeSuperior1800> RecuperarPorTerritorioId(int territorioId);
}