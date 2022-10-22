using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaServidaoAdministrativa
{
    IReadOnlyList<AreaServidaoAdministrativa> RecuperarTodos();

    IReadOnlyList<AreaServidaoAdministrativa> RecuperarPorTerritorioId(int territorioId);
}