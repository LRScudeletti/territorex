using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaDeclividadeMaior45
{
    IReadOnlyList<Area> RecuperarTodos();

    IReadOnlyList<Area> RecuperarPorTerritorioId(int territorioId);
}