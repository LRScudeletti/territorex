using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface ISituacaoImovel
{
    IReadOnlyList<SituacaoImovel> RecuperarTodos();

    SituacaoImovel RecuperarPorId(int situacaoImovelId);
}

