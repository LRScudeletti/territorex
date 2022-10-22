using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaReservaLegal
{
    IReadOnlyList<AreaReservaLegal> RecuperarTodos();

    IReadOnlyList<AreaReservaLegal> RecuperarPorTerritorioId(int territorioId);
}