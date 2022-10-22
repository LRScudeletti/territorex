using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces.Area;

public interface IAreaVegetacaoNativa
{
    IReadOnlyList<AreaVegetacaoNativa> RecuperarTodos();

    IReadOnlyList<AreaVegetacaoNativa> RecuperarPorTerritorioId(int territorioId);
}