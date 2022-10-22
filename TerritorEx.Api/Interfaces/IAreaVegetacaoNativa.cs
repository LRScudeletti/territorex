using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaVegetacaoNativa
{
    IReadOnlyList<AreaVegetacaoNativa> RecuperarTodos();

    IReadOnlyList<AreaVegetacaoNativa> RecuperarPorTerritorioId(int territorioId);
}