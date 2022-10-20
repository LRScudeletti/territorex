using TerritorEx.Api.Models.Area;

namespace TerritorEx.Api.Interfaces;

public interface IAreaPreservacaoPermanente
{
    IReadOnlyList<AreaPreservacaoPermanente> RecuperarTodos();

    IReadOnlyList<AreaPreservacaoPermanente> RecuperarPorTerritorioId(int territorioId);
}