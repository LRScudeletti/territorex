using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaReservaLegal
{
    IReadOnlyList<AreaReservaLegal> RecuperarTodos();

    IReadOnlyList<AreaReservaLegal> RecuperarPorTerritorioId(int territorioId);
}