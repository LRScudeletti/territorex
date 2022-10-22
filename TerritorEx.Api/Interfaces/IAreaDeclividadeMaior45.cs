using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaDeclividadeMaior45
{
    IReadOnlyList<AreaDeclividadeMaior45> RecuperarTodos();

    IReadOnlyList<AreaDeclividadeMaior45> RecuperarPorTerritorioId(int territorioId);
}