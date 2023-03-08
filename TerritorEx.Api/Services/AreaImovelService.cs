using Microsoft.Extensions.Localization;
using TerritorEx.Api.Interfaces;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Models;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

public class AreaImovelService : IAreaImovel
{
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaImovelService(IStringLocalizer<Resources> localizer)
    {
        _localizer = localizer;
    }

    public IReadOnlyList<AreaImovel> RecuperarTodos()
    {
        var area = AreaImovelRepository.RecuperarTodos();

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }

    public IReadOnlyList<AreaImovel> RecuperarPorTerritorioId(int territorioId)
    {
        var area = AreaImovelRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }

    public IReadOnlyList<AreaImovel> RecuperarPorImovelId(string imovelId)
    {
        var area = AreaImovelRepository.RecuperarPorImovelId(imovelId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }

    public IReadOnlyList<AreaImovel> RecuperarPorTipoImovelId(int tipoImovelId)
    {
        var area = AreaImovelRepository.RecuperarPorTipoImovelId(tipoImovelId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }

    public IReadOnlyList<AreaImovel> RecuperarPorSituacaoImovelId(int situacaoImovelId)
    {
        var area = AreaImovelRepository.RecuperarPorSituacaoImovelId(situacaoImovelId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }
}