using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaAltitudeSuperior1800
{
    IEnumerable<AreaAltitudeSuperior1800> RecuperarTodos();
}