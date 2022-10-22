using TerritorEx.Api.Models;

namespace TerritorEx.Api.Interfaces;

public interface IAreaImovel
{
    IReadOnlyList<AreaImovel> RecuperarTodos();

    IReadOnlyList<AreaImovel> RecuperarPorTerritorioId(int territorioId);

    IReadOnlyList<AreaImovel> RecuperarPorImovelId(string imovelId);

    IReadOnlyList<AreaImovel> RecuperarPorTipoImovelId(int tipoImovelId);

    IReadOnlyList<AreaImovel> RecuperarPorSituacaoImovelId(int situacaoImovelId);
}