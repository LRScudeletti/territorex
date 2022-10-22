using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces.Area;

public interface IAreaServidaoAdministrativa
{
    IReadOnlyList<AreaServidaoAdministrativa> RecuperarTodos();

    IReadOnlyList<AreaServidaoAdministrativa> RecuperarPorTerritorioId(int territorioId);
}