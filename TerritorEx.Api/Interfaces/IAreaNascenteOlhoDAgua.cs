using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaNascenteOlhoDAgua
{
    IReadOnlyList<AreaNascenteOlhoDAgua> RecuperarTodos();

    IReadOnlyList<AreaNascenteOlhoDAgua> RecuperarPorTerritorioId(int territorioId);
}