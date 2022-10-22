using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces.Area;

public interface IAreaNascenteOlhoDAgua
{
    IReadOnlyList<AreaNascenteOlhoDAgua> RecuperarTodos();

    IReadOnlyList<AreaNascenteOlhoDAgua> RecuperarPorTerritorioId(int territorioId);
}