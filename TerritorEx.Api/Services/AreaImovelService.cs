using Microsoft.Extensions.Localization;
using TerritorEx.Api.Entities;
using TerritorEx.Api.Localize;
using TerritorEx.Api.Repositories;

namespace TerritorEx.Api.Services;

#region [ Interfaces ]
public interface IAreaImovelService
{
    Task<IEnumerable<AreaImovel>> RecuperarTodos();
    Task<IReadOnlyCollection<AreaImovel>> RecuperarPorTerritorioId(int territorioId);
    Task<AreaImovel> RecuperarPorImovelId(string imovelId);
    Task<IReadOnlyCollection<AreaImovel>> RecuperarPorTipoImovelId(int tipoImovelId);
    Task<IReadOnlyCollection<AreaImovel>> RecuperarPorSituacaoImovelId(int situacaoImovelId);
}
#endregion

#region [ Services ]
public class AreaImovelService : IAreaImovelService
{
    private readonly IAreaImovelRepository _areaImovelRepository;
    private readonly IStringLocalizer<Resources> _localizer;

    public AreaImovelService(IAreaImovelRepository areaImovelRepository, IStringLocalizer<Resources> localizer)
    {
        _areaImovelRepository = areaImovelRepository;
        _localizer = localizer;
    }

    public async Task<IEnumerable<AreaImovel>> RecuperarTodos()
    {
        return await _areaImovelRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaImovel>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await _areaImovelRepository.RecuperarPorTerritorioId(territorioId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }

    public async Task<AreaImovel> RecuperarPorImovelId(string imovelId)
    {
        var area = await _areaImovelRepository.RecuperarPorImovelId(imovelId);

        if (area == null)
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }

    public async Task<IReadOnlyCollection<AreaImovel>> RecuperarPorTipoImovelId(int tipoImovelId)
    {
        var area = await _areaImovelRepository.RecuperarPorTipoImovelId(tipoImovelId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }

    public async Task<IReadOnlyCollection<AreaImovel>> RecuperarPorSituacaoImovelId(int situacaoImovelId)
    {
        var area = await _areaImovelRepository.RecuperarPorSituacaoImovelId(situacaoImovelId);

        if (!area.Any())
            throw new KeyNotFoundException(_localizer["area_territorio_nao_encontrado"]);

        return area;
    }
}
#endregion