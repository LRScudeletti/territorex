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
public class AreaImovelService(IAreaImovelRepository areaImovelRepository, IStringLocalizer<Resources> localizer)
    : IAreaImovelService
{
    public async Task<IEnumerable<AreaImovel>> RecuperarTodos()
    {
        return await areaImovelRepository.RecuperarTodos();
    }

    public async Task<IReadOnlyCollection<AreaImovel>> RecuperarPorTerritorioId(int territorioId)
    {
        var area = await areaImovelRepository.RecuperarPorTerritorioId(territorioId);

        if (area.Count == 0)
            throw new KeyNotFoundException(localizer["area_territorio_nao_encontrado"]);

        return area;
    }

    public async Task<AreaImovel> RecuperarPorImovelId(string imovelId)
    {
        var area = await areaImovelRepository.RecuperarPorImovelId(imovelId);

        if (area == null)
            throw new KeyNotFoundException(localizer["area_territorio_nao_encontrado"]);

        return area;
    }

    public async Task<IReadOnlyCollection<AreaImovel>> RecuperarPorTipoImovelId(int tipoImovelId)
    {
        var area = await areaImovelRepository.RecuperarPorTipoImovelId(tipoImovelId);

        if (area.Count == 0)
            throw new KeyNotFoundException(localizer["area_territorio_nao_encontrado"]);

        return area;
    }

    public async Task<IReadOnlyCollection<AreaImovel>> RecuperarPorSituacaoImovelId(int situacaoImovelId)
    {
        var area = await areaImovelRepository.RecuperarPorSituacaoImovelId(situacaoImovelId);

        if (area.Count == 0)
            throw new KeyNotFoundException(localizer["area_territorio_nao_encontrado"]);

        return area;
    }
}
#endregion