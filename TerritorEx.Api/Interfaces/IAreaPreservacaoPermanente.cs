using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaPreservacaoPermanente
{
    IReadOnlyList<AreaPreservacaoPermanente> RecuperarTodos();

    IReadOnlyList<AreaPreservacaoPermanente> RecuperarPorTerritorioId(int territorioId);
}