using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaImovelService
{
    Task<IEnumerable<AreaImovel>> RecuperarTodos();
    Task<IEnumerable<AreaImovel>> RecuperarPorTerritorioId(int territorioId);
    Task<AreaImovel> RecuperarPorImovelId(string imovelId);
    Task<IEnumerable<AreaImovel>> RecuperarPorTipoImovelId(int tipoImovelId);
    Task<IEnumerable<AreaImovel>> RecuperarPorSituacaoImovelId(int situacaoImovelId);
}
#endregion

#region [ Services ]
public class AreaImovelService : IAreaImovelService
{
    private readonly IAreaImovelRepository _areaImovelRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaImovelService(
        IAreaImovelRepository areaImovelRepository, 
        IStringLocalizer<Resources> localizer)
    {
        _areaImovelRepository = areaImovelRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaImovel>> RecuperarTodos()
    {
        var area = await _areaImovelRepository.RecuperarTodos();

        if (area == null)
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }

    public async Task<IEnumerable<AreaImovel>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaImovelRepository.RecuperarPorTerritorioId(territorioId);

        if (area == null)
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }

    public async Task<AreaImovel> RecuperarPorImovelId(string imovelId)
    {
        var area = await _areaImovelRepository.RecuperarPorImovelId(imovelId);

        if (area == null)
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }

    public async Task<IEnumerable<AreaImovel>> RecuperarPorTipoImovelId(int tipoImovelId)
    {
        var area = await _areaImovelRepository.RecuperarPorTipoImovelId(tipoImovelId);

        if (area == null)
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }

    public async Task<IEnumerable<AreaImovel>> RecuperarPorSituacaoImovelId(int situacaoImovelId)
    {
        var area = await _areaImovelRepository.RecuperarPorSituacaoImovelId(situacaoImovelId);

        if (area == null)
            throw new KeyNotFoundException(_localizer["area_nao_encontrada"]);

        return area;
    }
}
#endregion