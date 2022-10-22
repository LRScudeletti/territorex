using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaImovelService : IAreaImovel
{
    public IReadOnlyList<AreaImovel> RecuperarTodos()
    {
        var area = AreaImovelRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaImovel> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaImovelRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaImovel> RecuperarPorImovelId(string imovelId)
    {
        var area = AreaImovelRepository.RecuperarPorImovelId(imovelId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaImovel> RecuperarPorTipoImovelId(int tipoImovelId)
    {
        var area = AreaImovelRepository.RecuperarPorTipoImovelId(tipoImovelId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }

    public IReadOnlyList<AreaImovel> RecuperarPorSituacaoImovelId(int situacaoImovelId)
    {
        var area = AreaImovelRepository.RecuperarPorSituacaoImovelId(situacaoImovelId);

        if (!area.Any())
            throw new KeyNotFoundException(Properties.Resources.AreaNaoEncontrada);

        return area;
    }
}