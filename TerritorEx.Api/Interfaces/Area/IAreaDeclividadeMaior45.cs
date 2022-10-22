using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces.Area;

public interface IAreaDeclividadeMaior45
{
    IReadOnlyList<AreaDeclividadeMaior45> RecuperarTodos();

    IReadOnlyList<AreaDeclividadeMaior45> RecuperarPorTerritorioId(int territorioId);
}